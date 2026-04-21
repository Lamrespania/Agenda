namespace Agenda.UI.Common.Facade;

public class AppointmentFacade(IRetryService retryService, ILoginService loginService, IAppointmentService appointmentService) : IAppointmentFacade
{
    private readonly IRetryService _retryService = retryService;
    private readonly ILoginService _loginService = loginService;
    private readonly IAppointmentService _appointmentService = appointmentService;
    private Action _actionLogin;
    private string _username;
    private string _refreshToken;

    public void SetActionLogin(Action actionLogin)
    {
        _actionLogin = actionLogin;
    }

    public void SetProperties(string username, string token, string refreshToken)
    {
        _appointmentService.Token = token;
        _username = username;
        _refreshToken = refreshToken;
    }

    public void GetProperties(out string username, out string token, out string refreshToken)
    {
        username = _username;
        token = _appointmentService.Token;
        refreshToken = _refreshToken;
    }

    public async Task<IEnumerable<Appointment>> Get(CancellationToken cancellationToken)
    {
        IEnumerable<Appointment> appointments = null;

        Func<Task> getAppointments = async () => appointments = await _appointmentService.Get(cancellationToken);

        Func<Task<bool>> getFunc = async () => await BaseAction(getAppointments, cancellationToken);

        await _retryService.InvokeRetry(getFunc);

        return appointments;
    }

    public async Task<bool> Delete(int id, CancellationToken cancellationToken)
    {
        Func<Task<bool>> deleteFunc = async () =>
        {
            Func<Task> func = async () => await _appointmentService.Delete(id, cancellationToken);

            return await BaseAction(func, cancellationToken);
        };

        return await _retryService.InvokeRetry(deleteFunc);
    }

    public async Task<bool> Insert(Appointment appointment, CancellationToken cancellationToken)
    {
        Func<Task<bool>> insertFunc = async () =>
        {
            Func<Task> func = async () => await _appointmentService.Insert(appointment, cancellationToken);

            return await BaseAction(func, cancellationToken);
        };

        return await _retryService.InvokeRetry(insertFunc);
    }

    public async Task<bool> Update(Appointment appointment, CancellationToken cancellationToken)
    {
        Func<Task<bool>> updateFunc = async () =>
        {
            Func<Task> func = async () => await _appointmentService.Update(appointment, cancellationToken);

            return await BaseAction(func, cancellationToken);
        };

        return await _retryService.InvokeRetry(updateFunc);
    }

    private async Task<bool> BaseAction(Func<Task> func, CancellationToken cancellationToken)
    {
        try
        {
            await func.Invoke();

            return true;
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
            throw;
        }
        catch (OperationCanceledException)
        {
            throw new TimeoutException();
        }
        catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
        {
            await Refresh(cancellationToken);

            return false;
        }
        catch
        {
            return false;
        }
    }

    private async Task Refresh(CancellationToken cancellationToken)
    {
        TokenDto response = await _loginService.Refresh(new(_username, _refreshToken), cancellationToken);

        if (response.Valid)
        {
            _appointmentService.Token = response.Token;
            return;
        }

        _actionLogin.Invoke();
    }
}