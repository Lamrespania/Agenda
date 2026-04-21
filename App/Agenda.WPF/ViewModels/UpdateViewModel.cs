namespace Agenda.WPF.ViewModels;

public class UpdateViewModel
{
    public ICommand UpdateCommand { get; set; }
    public ICommand CancelCommand { get; set; }
    public string Id { get; set; }
    public string Comment { get; set; }
    public Array Types { get; set; } = Enum.GetValues<AppointmentType>();
    public AppointmentType TypeSelected { get; set; }
    public DateTime Date { get; set; }

    public UpdateViewModel()
    {
        UpdateCommand = new RelayCommand(_ => Update());
        CancelCommand = new RelayCommand(_ => Cancel());
    }

    public void SetAppointment(Appointment appointment)
    {
        Id = appointment.Id.ToString();
        Comment = appointment.Comment;
        TypeSelected = appointment.Type;
        Date = appointment.Date;
    }

    private void Update()
    {
        this.Close(true);
    }

    private void Cancel()
    {
        this.Close(false);
    }
}