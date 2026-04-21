namespace Agenda.Blazor.ViewModels;

public class LoginViewModel(
    ILogger<LoginViewModel> logger,
    NavigationManager navigationManager,
    ICustomDialogService dialogService,
    ILoginService loginService)
{
    private readonly ILogger<LoginViewModel> _logger = logger;
    private readonly NavigationManager _navigationManager = navigationManager;
    private readonly ICustomDialogService _dialogService = dialogService;
    private readonly ILoginService _loginService = loginService;

    public string Username { get; set; }
    public string Password { get; set; }
    public TokenDto TokenDto { get; set; } = new(false, null, null);
    public bool Disabled { get; set; }

    public async Task Login()
    {
        try
        {
            _logger.LogInformation("Begin login.");

            Disabled = true;

            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                _dialogService.Show("Please enter a correct usarname and password.", Severity.Normal);
                return;
            }

            TokenDto = await _loginService.Login(new(Username, Password), CancellationToken.None);
        }
        catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
        {
            _dialogService.Show("Incorrect credentials.", Severity.Warning);
        }
        catch (Exception ex)
        {
			_logger.LogError(ex, ex.Message);
            _dialogService.Show("Internal error.", Severity.Error);
        }
        finally
        {
            Disabled = false;

            if (TokenDto.Valid)
                Redirect();
        }
    }

    private void Redirect()
    {
        Password = string.Empty;

        string url = $"/LoginCallback?";
        url += $"username={Uri.EscapeDataString(Username)}&";
        url += $"token={Uri.EscapeDataString(TokenDto.Token)}&";
        url += $"refreshToken={Uri.EscapeDataString(TokenDto.RefreshToken)}";

        _navigationManager.NavigateTo(url, true);
    }
}