namespace Agenda.WinForms;

internal static class Program
{
    private static DIService diService;

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        CheckEnvironmentVariables();

        diService = new();

        using Login loginForm = diService.GetRequiredService<Login>();

        if (loginForm.ShowDialog() == DialogResult.OK)
        {
            IDialogService dialogService = diService.GetRequiredService<IDialogService>();
            IAppointmentFacade appointmentFacade = diService.GetRequiredService<IAppointmentFacade>();

            ConfigureAppointmentFacade(appointmentFacade, loginForm);

            Application.Run(new Main(dialogService, appointmentFacade));
        }
    }

    /// <summary>
    /// Check if environment variables exists and have a value.
    /// </summary>
    private static void CheckEnvironmentVariables()
    {
        FormConstants.API_URL
            .CheckEnvVarMissing()
            .CheckUrlFormat();

        FormConstants.API_TIMEOUT_SEC
            .CheckEnvVarMissing()
            .CheckEnvVarShortValue();
    }

    /// <summary>
    /// Set required values and login mechanism for retry process.
    /// </summary>
    private static void ConfigureAppointmentFacade(IAppointmentFacade appointmentFacade, Login loginForm)
    {
        Action actionLogin = () =>
        {
            using Login refreshLogin = diService.GetRequiredService<Login>();

            refreshLogin.SetTxtUsername(loginForm.Username);

            if (refreshLogin.ShowDialog() == DialogResult.OK)
                appointmentFacade.SetProperties(refreshLogin.Username, refreshLogin.TokenDto.Token, refreshLogin.TokenDto.RefreshToken);
            else
                throw new Exception("Login was canceled.");
        };

        appointmentFacade.SetActionLogin(actionLogin);
        appointmentFacade.SetProperties(loginForm.Username, loginForm.TokenDto.Token, loginForm.TokenDto.RefreshToken);
    }
}