namespace Agenda.UI.Common.Interfaces;

public interface IAppointmentFacade
{
    Task<IEnumerable<Appointment>> Get(CancellationToken cancellationToken);
    Task<bool> Insert(Appointment appointment, CancellationToken cancellationToken);
    Task<bool> Update(Appointment appointment, CancellationToken cancellationToken);
    Task<bool> Delete(int id, CancellationToken cancellationToken);
    void SetActionLogin(Action actionLogin);
    void SetProperties(string username, string token, string refreshToken);
    void GetProperties(out string username, out string token, out string refreshToken);
}