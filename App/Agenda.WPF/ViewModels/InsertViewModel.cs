namespace Agenda.WPF.ViewModels;

public class InsertViewModel
{
    public ICommand InsertCommand { get; set; }
    public ICommand CancelCommand { get; set; }
    public string Comment { get; set; } = string.Empty;
    public Array Types { get; set; } = Enum.GetValues<AppointmentType>();
    public AppointmentType TypeSelected { get; set; } = AppointmentType.Default;
    public DateTime Date { get; set; } = DateTime.Now;

    public InsertViewModel()
    {
        InsertCommand = new RelayCommand(_ => Insert());
        CancelCommand = new RelayCommand(_ => Cancel());
    }

    private void Insert()
    {
        this.Close(true);
    }

    private void Cancel()
    {
        this.Close(false);
    }
}