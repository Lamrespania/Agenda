namespace Agenda.User.Grpc;

public class Program
{
    public static void Main(string[] args)
    {
        CheckEnvironmentVariables();

        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.ConfigureLogger();

        AddServices(builder);

        WebApplication app = builder.Build();

        app.MapGrpcService<GetService>();
        app.MapGrpcService<InsertService>();

        app.Run();
    }

    /// <summary>
    /// Check if environment variables exists and have a value.
    /// </summary>
    private static void CheckEnvironmentVariables()
    {
        GrpcConstants.USER_DB.CheckEnvVarMissing();
    }

    /// <summary>
    /// Add services to the container.
    /// </summary>
    private static void AddServices(WebApplicationBuilder builder)
    {
        builder.Services.AddGrpc();

        builder.Services.AddScoped<UserDbService>();
        builder.Services.AddDbContext<UserDbContext>(options =>
        {
            string userDbConn = Environment.GetEnvironmentVariable(GrpcConstants.USER_DB);
            string connectionString = string.Format(userDbConn, Path.Combine(Directory.GetCurrentDirectory(), "..", $"DB{Path.DirectorySeparatorChar}"));

            options.UseSqlite(connectionString);
        });
    }
}