namespace Agenda.Login.Grpc;

public class Program
{
    public static void Main(string[] args)
    {
        CheckEnvironmentVariables();

        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.ConfigureLogger();

        AddServices(builder);

        WebApplication app = builder.Build();

        app.MapGrpcService<LoginService>();
        app.MapGrpcService<RefreshService>();

        app.Run();
    }

    /// <summary>
    /// Check if environment variables exists and have a value.
    /// </summary>
    private static void CheckEnvironmentVariables()
    {
        GrpcConstants.USER_DB
            .CheckEnvVarMissing();

        GrpcConstants.USER_TOKEN_LIFETIME_MIN
            .CheckEnvVarMissing()
            .CheckEnvVarShortValue();

        GrpcConstants.USER_TOKEN_REFRESH_LIFETIME_HOUR
            .CheckEnvVarMissing()
            .CheckEnvVarShortValue();
    }

    /// <summary>
    /// Add services to the container.
    /// </summary>
    private static void AddServices(WebApplicationBuilder builder)
    {
        RsaSecurityKey rsa = KeyHelper.GetKey(Path.Combine("Keys", "private.key"));

        builder.Services.AddGrpc();
        builder.Services.AddSingleton(rsa);

        builder.Services.AddScoped<TokenService>();
        builder.Services.AddScoped<TokenControlDbService>();
        builder.Services.AddScoped<UserDbService>();
        builder.Services.AddDbContext<UserDbContext>(options =>
        {
            string userDbConn = Environment.GetEnvironmentVariable(GrpcConstants.USER_DB);
            string connectionString = string.Format(userDbConn, Path.Combine(Directory.GetCurrentDirectory(), "..", $"DB{Path.DirectorySeparatorChar}"));

            options.UseSqlite(connectionString);
        });
    }
}