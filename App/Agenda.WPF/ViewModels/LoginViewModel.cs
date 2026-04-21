namespace Agenda.WPF.ViewModels;

public class LoginViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private readonly ILogger<LoginViewModel> _logger;
    private readonly IDialogService _dialogService;
    private readonly ILoginService _loginService;

    public ICommand LoginCommand { get; }
    public string Username { get; set; }
    public string Password { get; set; }
    public TokenDto TokenDto { get; set; } = new(false, null, null);

    private bool _enabled = true;
    public bool Enabled
    {
        get { return _enabled; }
        set { _enabled = value; OnPropertyChanged(); }
    }

    public LoginViewModel(ILogger<LoginViewModel> logger, IDialogService dialogService, ILoginService loginService)
    {
        _logger = logger;
        _dialogService = dialogService;
        _loginService = loginService;

        LoginCommand = new RelayCommand(async _ => await Login(), _ => _enabled);
    }

    private async Task Login()
    {
        try
        {
            _logger.LogInformation("Begin login.");

            Enabled = false;

            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                _dialogService.Show("Please enter a correct usarname and password.");
                return;
            }

            TokenDto = await _loginService.Login(new(Username, Password), CancellationToken.None);
        }
        catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
        {
            _dialogService.Show("Incorrect credentials.");
        }
        catch
        {
            _dialogService.Show("Internal error.");
        }
        finally
        {
            Enabled = true;

            if (TokenDto.Valid)
            {
                Password = string.Empty;

                this.Close(true);
            }
        }
    }

    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new(propertyName));
    }
}