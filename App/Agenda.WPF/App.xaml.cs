namespace Agenda.WPF;

public partial class App : Application
{
    private IServiceProvider _serviceProvider;

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        CheckEnvironmentVariables();

        ConfigureServices();

        bool dialogResult = ShowLogin(out Login login);

        if (dialogResult)
        {
            ConfigureAppointmentFacade(login);

            MainWindow mainWindow = _serviceProvider.GetRequiredService<MainWindow>();

            Current.MainWindow = mainWindow;

            mainWindow.Show();
        }
        else
        {
            Current.Shutdown();
        }
    }

    /// <summary>
    /// Check if environment variables exists and have a value.
    /// </summary>
    private void CheckEnvironmentVariables()
    {
        WpfConstants.API_URL
            .CheckEnvVarMissing()
            .CheckUrlFormat();

        WpfConstants.API_TIMEOUT_SEC
            .CheckEnvVarMissing()
            .CheckEnvVarShortValue();
    }

    /// <summary>
    /// Add services to the container.
    /// </summary>
    private void ConfigureServices()
    {
        ServiceCollection services = new();

        services.ConfigureLogger(ResourceAssembly.GetName().Name, 1);

        string apiUrl = Environment.GetEnvironmentVariable(WpfConstants.API_URL);
        short apiTimeoutSec = Convert.ToInt16(Environment.GetEnvironmentVariable(WpfConstants.API_TIMEOUT_SEC));

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

        services.AddTransient<LoginViewModel>();
        services.AddTransient<InsertViewModel>();
        services.AddTransient<UpdateViewModel>();
        services.AddTransient<AppointmentViewModel>();

        services.AddTransient<Login>();
        services.AddTransient<Insert>();
        services.AddTransient<Update>();
        services.AddTransient<MainWindow>();

        _serviceProvider = services.BuildServiceProvider();
    }

    /// <summary>
    /// Show login and authenticate user.
    /// </summary>
    private bool ShowLogin(out Login login)
    {
        login = _serviceProvider.GetRequiredService<Login>();
        login.ShowDialog();

        return login.DialogResult == true;
    }

    /// <summary>
    /// Set required values and login mechanism for retry process.
    /// </summary>
    private void ConfigureAppointmentFacade(Login login)
    {
        LoginViewModel loginVM = (LoginViewModel)login.DataContext;

        Action actionLogin = () =>
        {
            IDialogService dialogService = _serviceProvider.GetRequiredService<IDialogService>();

            Login newLogin = _serviceProvider.GetRequiredService<Login>();
            LoginViewModel newLoginVM = (LoginViewModel)newLogin.DataContext;

            newLoginVM.Username = loginVM.Username;

            bool dialogResult = newLogin.ShowDialog() == true;

            if (dialogResult)
            {
                IAppointmentFacade newAppointmentFacade = _serviceProvider.GetRequiredService<IAppointmentFacade>();
                newAppointmentFacade.SetProperties(newLoginVM.Username, newLoginVM.TokenDto.Token, newLoginVM.TokenDto.RefreshToken);
            }
            else
            {
                dialogService.Show("Closing application.");

                throw new Exception("Login was canceled.");
            }
        };

        IAppointmentFacade appointmentFacade = _serviceProvider.GetRequiredService<IAppointmentFacade>();

        appointmentFacade.SetActionLogin(actionLogin);
        appointmentFacade.SetProperties(loginVM.Username, loginVM.TokenDto.Token, loginVM.TokenDto.RefreshToken);
    }
}