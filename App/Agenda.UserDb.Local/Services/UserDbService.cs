namespace Agenda.UserDb.Local.Services;

public class UserDbService(UserDbContext dbContext)
{
    private readonly UserDbContext _dbContext = dbContext;

    public async Task<User> Get(int id)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<User> Get(string username)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(f => f.Username == username);
    }

    public async Task<User> Get(string username, string password)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(f => f.Username == username && f.Password == password);
    }

    public async Task<InsertResponse> Insert(User user)
    {
        bool userExist = await _dbContext.Users.FirstOrDefaultAsync(f => f.Username == user.Username) != null;

        if (userExist)
            return new() { Id = 0, UserResponse = UserResponse.DUPLICATED };

        await _dbContext.Users.AddAsync(user);

        int rowsInserted = await _dbContext.SaveChangesAsync();

        if (rowsInserted == 1)
            return new() { Id = user.Id, UserResponse = UserResponse.OK };

        return new() { Id = 0, UserResponse = UserResponse.ERROR };
    }
}