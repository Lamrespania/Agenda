namespace Agenda.WinForms;

public partial class Update : Form
{
    private Appointment _appointment;

    public string Comment => txtComment.Text;
    public AppointmentType Type => (AppointmentType)cmbType.SelectedValue;
    public DateTime Date => dtpDate.Value;

    public Update(Appointment appointment)
    {
        InitializeComponent();
        SetAppointment(appointment);
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.OK;
        Close();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private void SetAppointment(Appointment appointment)
    {
        _appointment = appointment;

        cmbType.DataSource = Enum.GetValues<AppointmentType>();

        txtId.Text = _appointment.Id.ToString();
        txtComment.Text = _appointment.Comment;
        cmbType.SelectedItem = _appointment.Type;
        dtpDate.Value = _appointment.Date;
    }
}