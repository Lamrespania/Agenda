namespace Agenda.Blazor;

public class Program
{
    public static void Main(string[] args)
    {
        CheckEnvironmentVariables();

        SetCultureInfo();

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
        BlazorConstants.API_URL
            .CheckEnvVarMissing()
            .CheckUrlFormat();

        BlazorConstants.API_TIMEOUT_SEC
            .CheckEnvVarMissing()
            .CheckEnvVarShortValue();

        BlazorConstants.COOKIE_EXPIRE_HOUR
            .CheckEnvVarMissing()
            .CheckEnvVarShortValue();
    }

    /// <summary>
    /// Set culture info en-US with default date and time formats.
    /// </summary>
    private static void SetCultureInfo()
    {
        CultureInfo culture = new("en-US");

        culture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
        culture.DateTimeFormat.ShortTimePattern = "HH:mm";
        culture.DateTimeFormat.LongTimePattern = "HH:mm";
        culture.DateTimeFormat.FullDateTimePattern = "dd/MM/yyyy HH:mm";

        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;
    }

    /// <summary>
    /// Add services to the container.
    /// </summary>
    private static void AddServices(WebApplicationBuilder builder)
    {
        builder.Services.AddRazorPages();

        builder.Services
            .AddRazorComponents()
            .AddInteractiveServerComponents();

        builder.Services
            .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, ConfigureCookie);

        builder.Services.AddMudServices(ConfigureSnackbar);
        builder.Services.AddHttpClient(string.Empty, ConfigureHttpClient);

        builder.Services.AddTransient<IDialogService, DialogService>();
        builder.Services.AddTransient<ICustomDialogService, DialogService>();
        builder.Services.AddTransient<ILoginService, LoginService>();
        builder.Services.AddTransient<IRetryService, RetryService>();
        builder.Services.AddTransient<IAppointmentService, AppointmentService>();
        builder.Services.AddTransient<IAppointmentFacade, AppointmentFacade>();

        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<AppointmentViewModel>();
    }

    /// <summary>
    /// Configure the HTTP request pipeline.
    /// </summary>
    private static void ConfigurePipeline(WebApplication app)
    {
        app.UseMiddleware<ExceptionMiddleware>();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapRazorPages();

        app.MapRazorComponents<App>()
           .AddInteractiveServerRenderMode();

        app.UseAntiforgery();
    }

    /// <summary>
    /// Configure cookie authentication options with LoginPath and Timeout.
    /// </summary>
    private static void ConfigureCookie(CookieAuthenticationOptions options)
    {
        short cookieExpireHour = Convert.ToInt16(Environment.GetEnvironmentVariable(BlazorConstants.COOKIE_EXPIRE_HOUR));

        options.ExpireTimeSpan = TimeSpan.FromHours(cookieExpireHour);
        options.LoginPath = "/Login";
    }

    /// <summary>
    /// Configure Snackbar (position, duration, transition, etc) of MudBlazor.
    /// </summary>
    private static void ConfigureSnackbar(MudServicesConfiguration config)
    {
        config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopCenter;
        config.SnackbarConfiguration.RequireInteraction = false;
        config.SnackbarConfiguration.PreventDuplicates = false;
        config.SnackbarConfiguration.NewestOnTop = true;
        config.SnackbarConfiguration.ShowCloseIcon = true;
        config.SnackbarConfiguration.VisibleStateDuration = 3000;
        config.SnackbarConfiguration.HideTransitionDuration = 250;
        config.SnackbarConfiguration.ShowTransitionDuration = 250;
        config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
    }

    /// <summary>
    /// Configure HttpClient with BaseAddress and Timeout from environment variables.
    /// </summary>
    private static void ConfigureHttpClient(HttpClient httpClient)
    {
        string apiUrl = Environment.GetEnvironmentVariable(BlazorConstants.API_URL);
        short apiTimeoutSec = Convert.ToInt16(Environment.GetEnvironmentVariable(BlazorConstants.API_TIMEOUT_SEC));

        httpClient.BaseAddress = new(apiUrl);
        httpClient.Timeout = TimeSpan.FromSeconds(apiTimeoutSec);
    }
}