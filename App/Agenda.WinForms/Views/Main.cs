namespace Agenda.WinForms;

public partial class Main : Form
{
    private readonly IDialogService _dialogService;
    private readonly IAppointmentFacade _appointmentFacade;

    private IEnumerable<Appointment> _appointments;
    private CancellationTokenSource _cts;

    public Main(IDialogService dialogService, IAppointmentFacade appointmentFacade)
    {
        InitializeComponent();
        EnableAll();

        _dialogService = dialogService;
        _appointmentFacade = appointmentFacade;
    }

    private void tacAppointments_SelectedIndexChanged(object sender, EventArgs e)
    {
        EnableDeleteUpdate();
    }

    private async void btnGet_Click(object sender, EventArgs e)
    {
        DisableAll();

        await LoadAppointments();

        EnableAll();
    }

    private async void btnDelete_Click(object sender, EventArgs e)
    {
        Appointment selected = (Appointment)GetFocusedDataGridView().CurrentRow?.DataBoundItem;

        if (selected == null)
            return;

        bool confirmResult = await _dialogService.Show("Delete appointment", "Are you sure to delete the selected appointment?");

        if (confirmResult == false)
            return;

        DisableAll();

        _cts = new();

        bool deleteResult = await _appointmentFacade.Delete(selected.Id, _cts.Token);

        if (deleteResult)
            await LoadAppointments();

        EnableAll();
    }

    private async void btnInsert_Click(object sender, EventArgs e)
    {
        Insert insert = new();
        DialogResult confirmResult = insert.ShowDialog();

        if (confirmResult == DialogResult.Cancel)
            return;

        Appointment appointment = new(0, insert.Comment, insert.Type, insert.Date, DateTime.Now, null);

        DisableAll();

        _cts = new();

        bool insertResult = await _appointmentFacade.Insert(appointment, _cts.Token);

        if (insertResult)
            await LoadAppointments();

        EnableAll();
    }

    private async void btnUpdate_Click(object sender, EventArgs e)
    {
        Appointment appointment = (Appointment)GetFocusedDataGridView().CurrentRow?.DataBoundItem;

        if (appointment == null)
            return;

        Update update = new(appointment);
        DialogResult confirmResult = update.ShowDialog();

        if (confirmResult == DialogResult.Cancel)
            return;

        Appointment appointmentToUpdate = new(appointment.Id, update.Comment, update.Type, update.Date, appointment.Created, null);

        DisableAll();

        _cts = new();

        bool updateResult = await _appointmentFacade.Update(appointmentToUpdate, _cts.Token);

        if (updateResult)
            await LoadAppointments();

        EnableAll();
    }

    private async void btnCancel_Click(object sender, EventArgs e)
    {
        await Cancel();
    }

    private async void btnExit_Click(object sender, EventArgs e)
    {
        await Cancel();

        Close();
    }

    private async Task LoadAppointments()
    {
        _cts = new();

        _appointments = await _appointmentFacade.Get(_cts.Token);
        _appointments = _appointments?.OrderByDescending(o => o.Date)?.ToArray();

        LoadDataGridViews();
    }

    private void LoadDataGridViews()
    {
        if (_appointments == null)
            return;

        dgvAll.DataSource = _appointments;

        for (int rowIndex = 0; rowIndex < dgvAll.Rows.Count; rowIndex++)
        {
            DataGridViewRow currentRow = dgvAll.Rows[rowIndex];
            Appointment boundItem = (Appointment)currentRow.DataBoundItem;

            if (boundItem.Date < DateTime.Now)
                currentRow.DefaultCellStyle.BackColor = Color.PaleGoldenrod;
        }

        dgvCurrent.DataSource = _appointments?.Where(w => w.Date >= DateTime.Now)?.ToArray();
        dgvExpired.DataSource = _appointments?.Where(w => w.Date < DateTime.Now)?.ToArray();

        SetColumnsWidth(dgvAll);
        SetColumnsWidth(dgvCurrent);
        SetColumnsWidth(dgvExpired);
    }

    private void DisableAll()
    {
        dgvAll.Enabled = false;
        dgvCurrent.Enabled = false;
        dgvExpired.Enabled = false;

        btnGet.Enabled = false;
        btnDelete.Enabled = false;
        btnInsert.Enabled = false;
        btnUpdate.Enabled = false;
        btnExit.Enabled = false;

        btnCancel.Visible = true;
    }

    private void EnableAll()
    {
        dgvAll.Enabled = true;
        dgvCurrent.Enabled = true;
        dgvExpired.Enabled = true;

        btnGet.Enabled = true;
        btnInsert.Enabled = true;
        btnExit.Enabled = true;

        EnableDeleteUpdate();

        btnCancel.Visible = false;
    }

    private void EnableDeleteUpdate()
    {
        bool rowsExist = GetFocusedDataGridView().Rows.Count > 0 ? true : false;

        if (rowsExist)
        {
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
        }
        else
        {
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }
    }

    private DataGridView GetFocusedDataGridView()
    {
        if (tacAppointments.SelectedTab.Name == nameof(tapAll))
        {
            return dgvAll;
        }
        else if (tacAppointments.SelectedTab.Name == nameof(tapCurrent))
        {
            return dgvCurrent;
        }
        else
        {
            return dgvExpired;
        }
    }

    private void SetColumnsWidth(DataGridView dataGridView)
    {
        dataGridView.Columns[nameof(Appointment.Id)].Width = 100;
        dataGridView.Columns[nameof(Appointment.Type)].Width = 150;
        dataGridView.Columns[nameof(Appointment.Date)].Width = 200;
        dataGridView.Columns[nameof(Appointment.Created)].Width = 200;
        dataGridView.Columns[nameof(Appointment.Modified)].Width = 200;

        dataGridView.Columns[nameof(Appointment.Comment)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
    }

    private async Task Cancel()
    {
        if (_cts == null)
            return;

        await _cts.CancelAsync();
    }
}