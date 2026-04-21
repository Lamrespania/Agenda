namespace Agenda.WinForms;

public partial class Insert : Form
{
    public string Comment => txtComment.Text;
    public AppointmentType Type => (AppointmentType)cmbType.SelectedValue;
    public DateTime Date => dtpDate.Value;

    public Insert()
    {
        InitializeComponent();

        cmbType.DataSource = Enum.GetValues<AppointmentType>();
        dtpDate.Value = DateTime.Now;
    }

    private void btnInsert_Click(object sender, EventArgs e)
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