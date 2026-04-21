namespace Agenda.Domain;

public class Appointment(int id, string comment, AppointmentType type, DateTime date, DateTime created, DateTime? modified)
{
    public int Id { get; private set; } = id;
    public string Comment { get; private set; } = comment;
    public AppointmentType Type { get; private set; } = type;
    public DateTime Date { get; private set; } = date;
    public DateTime Created { get; private set; } = created;
    public DateTime? Modified { get; private set; } = modified;
}