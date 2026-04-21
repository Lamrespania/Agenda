namespace Agenda.WPF;

public partial class CustomDialog : Window
{
    public bool Result { get; private set; }

    public CustomDialog(string title, string message)
    {
        InitializeComponent();

        Title = title;
        txtMessage.Text = message;
    }

    private void btnOk_Click(object sender, RoutedEventArgs e)
    {
        Result = true;
        Close();
    }

    private void btnCancel_Click(object sender, RoutedEventArgs e)
    {
        Result = false;
        Close();
    }
}