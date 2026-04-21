namespace Agenda.UI.Common.Interfaces;

public interface IDialogService
{
    void Show(string message, Severity severity = Severity.Info);
    Task<bool> Show(string title, string message);
}