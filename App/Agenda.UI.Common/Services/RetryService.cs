namespace Agenda.UI.Common.Services;

public class RetryService(IDialogService dialogService) : IRetryService
{
    private IDialogService _dialogService = dialogService;

    public async Task<bool> InvokeRetry(Func<Task<bool>> func, int maxTries = 3)
    {
        int retryCount = 1;

        while (retryCount <= maxTries)
        {
            try
            {
                bool stop = await func.Invoke();

                if (stop)
                    return true;

                retryCount++;
            }
            catch (OperationCanceledException)
            {
                _dialogService.Show("The operation was canceled successfully.");

                return false;
            }
            catch (TimeoutException)
            {
                _dialogService.Show("The operation was canceled due to timeout.");

                return false;
            }
        }

        _dialogService.Show("Internal error.");

        return false;
    }
}