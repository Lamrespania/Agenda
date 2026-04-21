namespace Agenda.Blazor.ViewModels;

public class AppointmentViewModel(
    NavigationManager navigationManager,
    AuthenticationStateProvider authStateProvider,
    ICustomDialogService dialogService,
    IAppointmentFacade appointmentFacade)
{
    public event Action OnChange;

    private readonly NavigationManager _navigationManager = navigationManager;
    private readonly AuthenticationStateProvider _authStateProvider = authStateProvider;
    private readonly ICustomDialogService _dialogService = dialogService;
    private readonly IAppointmentFacade _appointmentFacade = appointmentFacade;

    private IEnumerable<Appointment> _appointments;
    private CancellationTokenSource _cts;

    public bool Disabled { get; set; } = false;
    public bool DisabledDelete { get; set; } = true;
    public bool DisabledUpdate { get; set; } = true;
    public bool CancelDisabled { get; set; } = false;
    public Appointment AppointmentsAllSelected { get; set; }
    public Appointment AppointmentsCurrentSelected { get; set; }
    public Appointment AppointmentsExpiredSelected { get; set; }
    public ObservableCollection<Appointment> AppointmentsAll { get; set; }
    public ObservableCollection<Appointment> AppointmentsCurrent { get; set; }
    public ObservableCollection<Appointment> AppointmentsExpired { get; set; }

    private int _indexTabSelected;
    public int IndexTabSelected
    {
        get { return _indexTabSelected; }
        set { _indexTabSelected = value; EnableAll(); }
    }

    public async Task SetAppointmentFacadeProperties()
    {
        _appointmentFacade.GetProperties(out string username, out string token, out string refreshToken);

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(token) || string.IsNullOrEmpty(refreshToken))
        {
            AuthenticationState authState = await _authStateProvider.GetAuthenticationStateAsync();
            ClaimsPrincipal claimsPrincipal = authState.User;

            username = claimsPrincipal.FindFirstValue(BlazorConstants.CLAIM_USERNAME);
            token = claimsPrincipal.FindFirstValue(BlazorConstants.CLAIM_TOKEN);
            refreshToken = claimsPrincipal.FindFirstValue(BlazorConstants.CLAIM_REFRESHTOKEN);

            _appointmentFacade.SetProperties(username, token, refreshToken);
        }

        Action actionLogin = () => _navigationManager.NavigateTo("/Logout", true);

        _appointmentFacade.SetActionLogin(actionLogin);
    }

    public async Task Get()
    {
        await BaseProcess(LoadAppointments);
    }

    public async Task Delete()
    {
        Appointment selected = GetSelected();

        if (selected == null)
            return;

        bool confirmResult = await _dialogService.Show("Delete appointment", "Are you sure to delete the selected appointment?");

        if (confirmResult == false)
            return;

        Func<Task> func = async () =>
        {
            bool deleteResult = await _appointmentFacade.Delete(selected.Id, _cts.Token);

            if (deleteResult)
                await LoadAppointments();
        };

        await BaseProcess(func);
    }

    public async Task Insert()
    {
        DialogResult dialogResult = await ShowInsertDialog();

        if (dialogResult.Canceled)
            return;

        Appointment appointment = (Appointment)dialogResult.Data;

        Func<Task> func = async () =>
        {
            bool insertResult = await _appointmentFacade.Insert(appointment, _cts.Token);

            if (insertResult)
                await LoadAppointments();
        };

        await BaseProcess(func);
    }

    public async Task Update()
    {
        Appointment appointment = GetSelected();

        if (appointment == null)
            return;

        DialogResult dialogResult = await ShowUpdateDialog(appointment);

        if (dialogResult.Canceled)
            return;

        Appointment appointmentToUpdate = (Appointment)dialogResult.Data;

        Func<Task> func = async () =>
        {
            bool updateResult = await _appointmentFacade.Update(appointmentToUpdate, _cts.Token);

            if (updateResult)
                await LoadAppointments();
        };

        await BaseProcess(func);
    }

    public async Task Cancel()
    {
        if (_cts == null)
            return;

        try
        {
            CancelDisabled = true;

            await _cts.CancelAsync();
        }
        finally
        {
            CancelDisabled = false;
        }
    }

    public async Task Exit()
    {
        await Cancel();

        _navigationManager.NavigateTo("/Logout", true);
    }

    private async Task BaseProcess(Func<Task> func)
    {
        try
        {
            _cts = new();

            DisableAll();
            NotifyStateChanged();

            await func.Invoke();
        }
        catch (TaskCanceledException)
        {
            _dialogService.Show("The operation was canceled successfully.");
        }
        finally
        {
            EnableAll();
            NotifyStateChanged();
        }
    }

    private async Task LoadAppointments()
    {
        _appointments = await _appointmentFacade.Get(_cts.Token);
        _appointments = _appointments?.OrderByDescending(o => o.Date)?.ToArray();

        LoadDataGridViews();
    }

    private async Task<DialogResult> ShowInsertDialog()
    {
        return await _dialogService.ShowAsync<InsertAppointment>("Insert", [], GetDialogOptions());
    }

    private async Task<DialogResult> ShowUpdateDialog(Appointment appointment)
    {
        DialogParameters parameters = new()
        {
            ["Id"] = appointment.Id,
            ["Comment"] = appointment.Comment,
            ["Type"] = appointment.Type,
            ["Date"] = appointment.Date,
            ["Created"] = appointment.Created
        };

        return await _dialogService.ShowAsync<UpdateAppointment>("Update", parameters, GetDialogOptions());
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
        Disabled = true;
        DisabledDelete = true;
        DisabledUpdate = true;
    }

    private void EnableAll()
    {
        Disabled = false;

        bool rowsExist = GetFocusedCollection()?.Count > 0;

        if (rowsExist)
        {
            DisabledDelete = false;
            DisabledUpdate = false;
        }
        else
        {
            DisabledDelete = true;
            DisabledUpdate = true;
        }
    }

    private ObservableCollection<Appointment> GetFocusedCollection()
    {
        if (IndexTabSelected == 0)
        {
            return AppointmentsAll;
        }
        else if (IndexTabSelected == 1)
        {
            return AppointmentsCurrent;
        }

        return AppointmentsExpired;
    }

    private Appointment GetSelected()
    {
        if (IndexTabSelected == 0)
        {
            return AppointmentsAllSelected;
        }
        else if (IndexTabSelected == 1)
        {
            return AppointmentsCurrentSelected;
        }

        return AppointmentsExpiredSelected;
    }

    private DialogOptions GetDialogOptions()
    {
        return new()
        {
            CloseOnEscapeKey = true,
            MaxWidth = MaxWidth.ExtraSmall,
            FullWidth = true
        };
    }

    private void NotifyStateChanged()
    {
        OnChange?.Invoke();
    }
}