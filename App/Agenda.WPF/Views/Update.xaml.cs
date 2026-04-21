namespace Agenda.WPF;

public partial class Update : Window
{
    public Update(UpdateViewModel updateVM)
    {
        InitializeComponent();

        DataContext = updateVM;
    }
}