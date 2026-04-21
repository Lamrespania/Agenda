namespace Agenda.WPF;

public partial class MainWindow : Window
{
    public MainWindow(AppointmentViewModel appointmentVM)
    {
        InitializeComponent();

        DataContext = appointmentVM;
    }
}