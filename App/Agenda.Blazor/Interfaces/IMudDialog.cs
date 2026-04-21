namespace Agenda.Blazor.Interfaces;

public interface ICustomDialogService : IDialogService
{
    Task<DialogResult> ShowAsync<T>(string title, DialogParameters parameters, DialogOptions options) where T : IComponent;
}