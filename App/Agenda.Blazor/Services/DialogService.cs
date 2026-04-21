namespace Agenda.Blazor.Services;

public class DialogService(ISnackbar snackbar, MudBlazor.IDialogService mudDialogService) : ICustomDialogService
{
    private readonly ISnackbar _snackbar = snackbar;
    private readonly MudBlazor.IDialogService _mudDialogService = mudDialogService;

    public void Show(string message, Severity severity = Severity.Info)
    {
        _snackbar.Add(message, (MudBlazor.Severity)severity);
    }

    public async Task<bool> Show(string title, string message)
    {
        bool? dialogResult = await _mudDialogService.ShowMessageBoxAsync(title, message, yesText: "Ok", cancelText: "Cancel");
        return dialogResult == true;
    }

    public async Task<DialogResult> ShowAsync<T>(string title, DialogParameters parameters, DialogOptions options) where T : IComponent
    {
        IDialogReference dialogReference = await _mudDialogService.ShowAsync<T>(title, parameters, options);

        return await dialogReference.Result;
    }
}