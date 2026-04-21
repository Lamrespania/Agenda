namespace Agenda.UI.Common.Interfaces;

public interface IAppointmentService
{
    public string Token { get; set; }

    Task<IEnumerable<Appointment>> Get(CancellationToken cancellationToken);
    Task Insert(Appointment appointment, CancellationToken cancellationToken);
    Task Update(Appointment appointment, CancellationToken cancellationToken);
    Task Delete(int id, CancellationToken cancellationToken);
}