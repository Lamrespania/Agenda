namespace Agenda.UI.Common.Interfaces;

public interface IRetryService
{
    Task<bool> InvokeRetry(Func<Task<bool>> func, int maxTries = 3);
}