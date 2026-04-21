namespace Agenda.WinForms.Services;

public class DIService : IDisposable
{
    private static ServiceProvider _provider;

    public DIService()
    {
        if (_provider != null)
            return;

        ServiceCollection services = new();

        services.ConfigureLogger(Application.ProductName, 1);

        string apiUrl = Environment.GetEnvironmentVariable(FormConstants.API_URL);
        short apiTimeoutSec = Convert.ToInt16(Environment.GetEnvironmentVariable(FormConstants.API_TIMEOUT_SEC));

        services.AddHttpClient(string.Empty, httpClient =>
        {
            httpClient.BaseAddress = new(apiUrl);
            httpClient.Timeout = TimeSpan.FromSeconds(apiTimeoutSec);
        });

        services.AddTransient<IDialogService, DialogService>();
        services.AddTransient<ILoginService, LoginService>();
        services.AddTransient<IRetryService, RetryService>();
        services.AddScoped<IAppointmentService, AppointmentService>();
        services.AddScoped<IAppointmentFacade, AppointmentFacade>();

        services.AddTransient<Login>();

        _provider = services.BuildServiceProvider();
    }

    public T GetRequiredService<T>()
    {
        return _provider.GetRequiredService<T>();
    }

    public void Dispose()
    {
        _provider?.Dispose();
    }
}