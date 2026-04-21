namespace Agenda.WinForms;

public partial class CustomDialog : Form
{
    public CustomDialog(string title, string message)
    {
        InitializeComponent();

        Text = title;
        rtbMessage.Text = message;
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.OK;
        Close();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}