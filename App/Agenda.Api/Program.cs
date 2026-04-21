namespace Agenda.Api;

public class Program
{
    public static void Main(string[] args)
    {
        CheckEnvironmentVariables();

        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.ConfigureLogger();

        AddServices(builder);

        WebApplication app = builder.Build();

        ConfigurePipeline(app);

        app.Run();
    }

    /// <summary>
    /// Check if environment variables exists and have a value.
    /// </summary>
    private static void CheckEnvironmentVariables()
    {
        ApiConstants.AGENDA_DB
            .CheckEnvVarMissing();

        ApiConstants.USER_SERVICE_URL
            .CheckEnvVarMissing()
            .CheckUrlFormat();

        ApiConstants.LOGIN_SERVICE_URL
            .CheckEnvVarMissing()
            .CheckUrlFormat();
    }

    /// <summary>
    /// Add services to the container.
    /// </summary>
    private static void AddServices(WebApplicationBuilder builder)
    {
        RsaSecurityKey rsa = KeyHelper.GetKey(Path.Combine("Keys", "public.key"));

        builder.Services.AddControllers();
        builder.Services.AddScoped<LoginService>();
        builder.Services.AddScoped<RefreshService>();
        builder.Services.AddScoped<UserService>();
        builder.Services.AddScoped<AppointmentDbService>();
        builder.Services.AddDbContext<AgendaDbContext>(options =>
        {
            string agendaDbConn = Environment.GetEnvironmentVariable(ApiConstants.AGENDA_DB);
            string connectionString = string.Format(agendaDbConn, Path.Combine(AppContext.BaseDirectory, $"DB{Path.DirectorySeparatorChar}"));
            options.UseSqlite(connectionString);
        });

        builder.Services.AddAuthorization();
        builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
        {
            options.TokenValidationParameters = new()
            {
                ValidateIssuer = true,
                ValidIssuer = CommonConstants.API_NAME,
                ValidateAudience = true,
                ValidAudience = CommonConstants.API_NAME,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = rsa,
                RoleClaimType = ClaimTypes.Role
            };
        });
    }

    /// <summary>
    /// Configure the HTTP request pipeline.
    /// </summary>
    private static void ConfigurePipeline(WebApplication app)
    {
        app.UseMiddleware<ExceptionMiddleware>();

        app.UseHttpsRedirection();

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();
    }
}