namespace Agenda.UserDb.Local.Services;

public class TokenControlDbService(UserDbContext dbContext)
{
    private readonly UserDbContext _dbContext = dbContext;

    public async Task<TokenControl> Get(int userId, string refreshToken)
    {
        return await _dbContext.TokensControl
            .FirstOrDefaultAsync(f => f.UserId == userId && f.RefreshToken == refreshToken);
    }

    public async Task<int> Insert(TokenControl tokenControl)
    {
        TokenControl userTokenControl = await _dbContext.TokensControl.FirstOrDefaultAsync(f => f.UserId == tokenControl.UserId);

        if (userTokenControl != null)
        {
            await Update(userTokenControl.Id, tokenControl.Token, tokenControl.RefreshToken, tokenControl.RefreshTokenExpiringDate);

            return userTokenControl.Id;
        }

        await _dbContext.TokensControl.AddAsync(tokenControl);

        int rowsInserted = await _dbContext.SaveChangesAsync();

        if (rowsInserted == 1)
            return tokenControl.Id;

        return 0;
    }

    public async Task<bool> Update(int id, string token, string refreshToken, DateTime refreshTokenExpiringDate)
    {
        int rowsUpdated = await _dbContext.TokensControl
            .Where(w => w.Id == id)
            .ExecuteUpdateAsync(setter => setter
                .SetProperty(s => s.Token, token)
                .SetProperty(s => s.RefreshToken, refreshToken)
                .SetProperty(s => s.RefreshTokenExpiringDate, refreshTokenExpiringDate)
        );

        if (rowsUpdated == 0)
            return false;

        return true;
    }
}