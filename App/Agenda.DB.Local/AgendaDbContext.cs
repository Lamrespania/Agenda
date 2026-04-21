namespace Agenda.DB.Local;

public class AgendaDbContext : DbContext
{
    public DbSet<Appointment> Appointments { get; set; }

    public AgendaDbContext(DbContextOptions<AgendaDbContext> options) : base(options) { }
}