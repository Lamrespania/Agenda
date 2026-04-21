### Configuración de EntityFramework para .NET Core
</br>

1. Paquetes nuget necesarios

```
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.Sqlite (En caso de usar Sqlite)
```

2. Configuración del contexto

```
namespace Agenda.UserDb.Local;

public class UserDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }
}
```

3. Configuración del program.cs

```
builder.Services.AddDbContext<UserDbContext>(options =>
{
    string loginDbPath = Environment.GetEnvironmentVariable(GrpcConstants.USER_DB);
    string dbPath = string.Format(loginDbPath, Path.Combine(AppContext.BaseDirectory, $"DB{Path.DirectorySeparatorChar}"));
    options.UseSqlite(dbPath);
});
```

4. Comandos para la migración

```
Ejecutamos en la ruta donde se encuentre la solución y las carpetas de los proyectos.
En este caso sería: "C:\Users\UserTest\Desktop\AgendaWebApi"

Para generar la migración:
    Agenda.db
    dotnet ef migrations add InitialCreation -p .\Agenda.DB.Local\Agenda.DB.Local.csproj -s .\AgendaWebApi\AgendaWebApi.csproj
    User.db
    dotnet ef migrations add InitialCreation -p .\Agenda.UserDb.Local\Agenda.UserDb.Local.csproj -s .\Agenda.Login.Grpc\Agenda.Login.Grpc.csproj

Actualizar base de datos
    Agenda.db
    dotnet ef database update -p .\Agenda.BD.Local\Agenda.BD.Local.csproj -s .\AgendaWebApi\AgendaWebApi.csproj
    User.db
    dotnet ef database update -p .\Agenda.UserDb.Local\Agenda.UserDb.Local.csproj -s .\Agenda.Login.Grpc\Agenda.Login.Grpc.csproj
```

5. Varios

```
Código para asegurarse de la estructura de las tablas de la bd

using IServiceScope scope = app.Services.CreateScope();
AgendaDbContext db = scope.ServiceProvider.GetRequiredService<AgendaDbContext>();
db.Database.EnsureCreated();
```
