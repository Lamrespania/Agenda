global using Microsoft.AspNetCore.Authentication;
global using Microsoft.AspNetCore.Authentication.Cookies;
global using Microsoft.AspNetCore.Components;
global using Microsoft.AspNetCore.Components.Authorization;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Mvc.RazorPages;

global using System.Collections.ObjectModel;
global using System.Globalization;
global using System.Net;
global using System.Security.Claims;

global using MudBlazor;
global using MudBlazor.Services;

global using Agenda.Common.Helpers;
global using Agenda.Domain;
global using Agenda.UI.Common.Dtos;
global using Agenda.UI.Common.Facade;
global using Agenda.UI.Common.Interfaces;
global using Agenda.UI.Common.Services;
global using Severity = Agenda.UI.Common.Enums.Severity;
global using IDialogService = Agenda.UI.Common.Interfaces.IDialogService;

global using Agenda.Blazor.Components;
global using Agenda.Blazor.Components.Dialogs;
global using Agenda.Blazor.Constants;
global using Agenda.Blazor.Interfaces;
global using Agenda.Blazor.ViewModels;
global using DialogService = Agenda.Blazor.Services.DialogService;