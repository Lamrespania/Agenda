namespace Agenda.UserDb.Local;

public class UserDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<TokenControl> TokensControl { get; set; }

    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        AddUsers(modelBuilder);
    }

    private void AddUsers(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData([
            new(1, "UserTest1", "PasswordTest1", UserRole.Admin, new DateTime(2026, 03, 01)),
            new(2, "UserTest2", "PasswordTest2", UserRole.Manager, new DateTime(2026, 03, 01))
        ]);
    }
}