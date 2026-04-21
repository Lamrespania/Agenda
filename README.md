# Agenda
Test crud projects (frontend and backend)

#### Technologies and Frameworks used

```
- .NET 9
- ASP.NET Core
- Docker
- gRPC
- Blazor
- MudBlazor
- WPF
- WinForms
- Entity Framework
- MySQL
```
</br>

The application can be divided into three parts: Frontend, Backend, and Common. Each part has its own role and responsibilities.

#### Frontend
```
- Agenda.UI.Common  
  Common library for UI projects.

- Agenda.WinForms  
  UI application built with WinForms.

- Agenda.WPF  
  UI application built with WPF.

- Agenda.Blazor  
  UI application built with Blazor Server.
```

#### Backend
```
- Agenda.Api  
  Web API responsible for receiving requests and handling login, token refresh, users and appointments.

- Agenda.User.Grpc  
  gRPC service responsible for handling users.

- Agenda.Login.Grpc  
  gRPC service responsible for handling login.

- Agenda.DB.Local  
  Library containing database functionality for appointments.

- Agenda.User.Local  
  Library containing database functionality for users.
```

#### Common
```
- Agenda.Common  
  Common library shared across all projects.

- Agenda.Domain  
  Common library containing the entities shared across all projects.
```
</br>

The following diagram represent the communication flow and dependencies across all projects in the solution.

#### Solution diagram

![](Docs/Diagramas/Diagrama%20de%20la%20solución.png)  
</br>

#### Related links

[Dependencies](Docs/Dependencies.md)  
[Environment variables](Docs/EnvironmentVariables.md)  
[Entity Framework](Docs/EF.md)
