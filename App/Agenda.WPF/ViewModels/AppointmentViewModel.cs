namespace Agenda.WPF.ViewModels;

public class AppointmentViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private readonly IServiceProvider _serviceProvider;
    private readonly IDialogService _dialogService;
    private readonly IAppointmentFacade _appointmentFacade;

    private IEnumerable<Appointment> _appointments;
    private CancellationTokenSource _cts;

    public ICommand GetCommand { get; set; }
    public ICommand DeleteCommand { get; set; }
    public ICommand InsertCommand { get; set; }
    public ICommand UpdateCommand { get; set; }
    public ICommand CancelCommand { get; set; }
    public ICommand ExitCommand { get; set; }
    public Appointment AppointmentsAllSelected { get; set; }
    public Appointment AppointmentsCurrentSelected { get; set; }
    public Appointment AppointmentsExpiredSelected { get; set; }

    private string _tabSelected;
    public string TabSelected
    {
        get { return _tabSelected; }
        set { _tabSelected = value; EnableAll(); }
    }

    private bool _enabled = true;
    public bool Enabled
    {
        get { return _enabled; }
        set { _enabled = value; OnPropertyChanged(); }
    }

    private bool _enabledDelete = false;
    public bool EnabledDelete
    {
        get { return _enabledDelete; }
        set { _enabledDelete = value; OnPropertyChanged(); }
    }

    private bool _enabledUpdate = false;
    public bool EnabledUpdate
    {
        get { return _enabledUpdate; }
        set { _enabledUpdate = value; OnPropertyChanged(); }
    }

    private ObservableCollection<Appointment> _appointmentsAll;
    public ObservableCollection<Appointment> AppointmentsAll
    {
        get { return _appointmentsAll; }
        set { _appointmentsAll = value; OnPropertyChanged(); }
    }

    private ObservableCollection<Appointment> _appointmentsCurrent;
    public ObservableCollection<Appointment> AppointmentsCurrent
    {
        get { return _appointmentsCurrent; }
        set { _appointmentsCurrent = value; OnPropertyChanged(); }
    }

    private ObservableCollection<Appointment> _appointmentsExpired;
    public ObservableCollection<Appointment> AppointmentsExpired
    {
        get { return _appointmentsExpired; }
        set { _appointmentsExpired = value; OnPropertyChanged(); }
    }

    public AppointmentViewModel(IServiceProvider serviceProvider, IDialogService dialogService, IAppointmentFacade appointmentFacade)
    {
        _serviceProvider = serviceProvider;
        _dialogService = dialogService;
        _appointmentFacade = appointmentFacade;

        GetCommand = new RelayCommand(async _ => await Get());
        DeleteCommand = new RelayCommand(async _ => await Delete());
        InsertCommand = new RelayCommand(async _ => await Insert());
        UpdateCommand = new RelayCommand(async _ => await Update());
        CancelCommand = new RelayCommand(async _ => await Cancel());
        ExitCommand = new RelayCommand(async _ => await Exit());
    }

    private async Task Get()
    {
        DisableAll();

        await LoadAppointments();

        EnableAll();
    }

    private async Task Delete()
    {
        Appointment selected = GetSelected();

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

    private async Task Insert()
    {
        Insert insert = _serviceProvider.GetRequiredService<Insert>();
        insert.ShowDialog();

        if (insert.DialogResult == false)
            return;

        InsertViewModel insertVM = (InsertViewModel)insert.DataContext;

        Appointment appointment = new(0, insertVM.Comment, insertVM.TypeSelected, insertVM.Date, DateTime.Now, null);

        DisableAll();

        _cts = new();

        bool insertResult = await _appointmentFacade.Insert(appointment, _cts.Token);

        if (insertResult)
            await LoadAppointments();

        EnableAll();
    }

    private async Task Update()
    {
        Appointment appointment = GetSelected();

        if (appointment == null)
            return;

        Update update = _serviceProvider.GetRequiredService<Update>();

        UpdateViewModel updateVM = (UpdateViewModel)update.DataContext;
        updateVM.SetAppointment(appointment);

        update.ShowDialog();

        if (update.DialogResult == false)
            return;

        Appointment appointmentToUpdate = new(appointment.Id, updateVM.Comment, updateVM.TypeSelected, updateVM.Date, appointment.Created, null);

        DisableAll();

        _cts = new();

        bool updateResult = await _appointmentFacade.Update(appointmentToUpdate, _cts.Token);

        if (updateResult)
            await LoadAppointments();

        EnableAll();
    }

    private async Task Cancel()
    {
        if (_cts == null)
            return;

        await _cts.CancelAsync();
    }

    private async Task Exit()
    {
        await Cancel();

        this.Close();
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

        AppointmentsAll = new(_appointments);
        AppointmentsCurrent = new(_appointments?.Where(w => w.Date >= DateTime.Now));
        AppointmentsExpired = new(_appointments?.Where(w => w.Date < DateTime.Now));
    }

    private void DisableAll()
    {
        Enabled = false;
        EnabledDelete = false;
        EnabledUpdate = false;
    }

    private void EnableAll()
    {
        Enabled = true;

        bool rowsExist = GetFocusedCollection()?.Count > 0;

        if (rowsExist)
        {
            EnabledDelete = true;
            EnabledUpdate = true;
        }
        else
        {
            EnabledDelete = false;
            EnabledUpdate = false;
        }
    }

    private ObservableCollection<Appointment> GetFocusedCollection()
    {
        if (TabSelected.Contains("All"))
        {
            return AppointmentsAll;
        }
        else if (TabSelected.Contains("Current"))
        {
            return AppointmentsCurrent;
        }

        return AppointmentsExpired;
    }

    private Appointment GetSelected()
    {
        if (TabSelected.Contains("All"))
        {
            return AppointmentsAllSelected;
        }
        else if (TabSelected.Contains("Current"))
        {
            return AppointmentsCurrentSelected;
        }

        return AppointmentsExpiredSelected;
    }

    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new(propertyName));
    }
}