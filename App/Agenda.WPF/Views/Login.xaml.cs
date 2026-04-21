namespace Agenda.WPF;

public partial class Login : Window
{
    public Login(LoginViewModel loginVM)
    {
        InitializeComponent();

        DataContext = loginVM;
    }

    public void LoginPasswordChanged(object sender, RoutedEventArgs e)
    {
        if (DataContext is LoginViewModel vm)
            vm.Password = LoginPassword.Password;
    }
}