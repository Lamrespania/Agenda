namespace Agenda.WinForms;

public partial class Login : Form
{
    private readonly ILogger<Login> _logger;
    private readonly ILoginService _loginService;

    public string Username { get; private set; }
    public TokenDto TokenDto { get; private set; } = new(false, null, null);

    public Login(ILogger<Login> logger, ILoginService loginService)
    {
        InitializeComponent();

        _logger = logger;
        _loginService = loginService;
    }

    public void SetTxtUsername(string username)
    {
        txtUsername.Text = username;
    }

    private async void btnLogin_Click(object sender, EventArgs e)
    {
        txtUsername.Enabled = false;
        txtPassword.Enabled = false;
        btnLogin.Enabled = false;

        try
        {
            _logger.LogInformation("Begin login.");

            Username = txtUsername.Text;

            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please enter a correct usarname and password.");
                return;
            }

            TokenDto = await _loginService.Login(new(txtUsername.Text, txtPassword.Text), CancellationToken.None);
        }
        catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
        {
            MessageBox.Show("Incorrect credentials.");
        }
        catch
        {
            MessageBox.Show("Internal error.");
        }
        finally
        {
            txtUsername.Enabled = true;
            txtPassword.Enabled = true;
            btnLogin.Enabled = true;

            if (TokenDto.Valid)
            {
                txtUsername.Text = string.Empty;
                txtPassword.Text = string.Empty;

                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}