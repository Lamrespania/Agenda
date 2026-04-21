namespace Agenda.WPF.Helpers;

public static class ViewModelHelper
{
    /// <summary>
    /// Close window of parameter view model.
    /// </summary>
    public static void Close(this object viewModel)
    {
        Window window = Application.Current.Windows.OfType<Window>().FirstOrDefault(f => f.DataContext == viewModel);
        window?.Close();
    }

    /// <summary>
    /// Close window of parameter view model and set DialogResult of window.
    /// </summary>
    public static void Close(this object viewModel, bool dialogResult)
    {
        Window window = Application.Current.Windows.OfType<Window>().FirstOrDefault(f => f.DataContext == viewModel);

        if (window != null)
        {
            window.DialogResult = dialogResult;
            window.Close();
        }
    }
}