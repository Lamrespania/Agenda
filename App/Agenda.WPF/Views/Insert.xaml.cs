namespace Agenda.WPF;

public partial class Insert : Window
{
    public Insert(InsertViewModel insertVM)
    {
        InitializeComponent();

        DataContext = insertVM;
    }
}