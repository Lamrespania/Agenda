namespace Agenda.DB.Local;

public class AppointmentDbService
{
    private readonly AgendaDbContext _dbContext;

    public AppointmentDbService(AgendaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Appointment>> Get()
    {
        return await _dbContext.Appointments.ToArrayAsync();
    }

    public async Task<Appointment> Get(int id)
    {
        return await _dbContext.Appointments.FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<int> Insert(Appointment appointment)
    {
        await _dbContext.Appointments.AddAsync(appointment);

        int rowsInserted = await _dbContext.SaveChangesAsync();

        if (rowsInserted == 1)
            return appointment.Id;

        return 0;
    }

    public async Task<bool> Update(Appointment appointment)
    {
        int rowsUpdated = await _dbContext.Appointments
            .Where(w => w.Id == appointment.Id)
            .ExecuteUpdateAsync(setter => setter
                .SetProperty(s => s.Comment, appointment.Comment)
                .SetProperty(s => s.Type, appointment.Type)
                .SetProperty(s => s.Date, appointment.Date)
                .SetProperty(s => s.Modified, DateTime.Now)
            );

        if (rowsUpdated == 0)
            return false;

        return true;
    }

    public async Task<bool> Delete(int id)
    {
        int rowsDeleted = await _dbContext.Appointments
            .Where(w => w.Id == id)
            .ExecuteDeleteAsync();

        if (rowsDeleted == 0)
            return false;

        return true;
    }
}