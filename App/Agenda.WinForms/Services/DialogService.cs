namespace Agenda.WinForms.Services;

public class DialogService : IDialogService
{
    public void Show(string message, Severity severity = Severity.Info)
    {
        MessageBox.Show(message);
    }

    public async Task<bool> Show(string title, string message)
    {
        CustomDialog dialog = new(title, message);

        bool dialogResult = dialog.ShowDialog() == DialogResult.OK;

        return await Task.FromResult(dialogResult);
    }
}