namespace Agenda.Blazor.Components;

public class AnonymousPageBase : ComponentBase
{
    [Inject]
    private NavigationManager _navigationManager { get; set; }
    [Inject]
    private AuthenticationStateProvider _authStateProvider { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender == false)
            return;

        AuthenticationState authState = await _authStateProvider.GetAuthenticationStateAsync();
        ClaimsPrincipal claimsPrincipal = authState?.User;

        if (claimsPrincipal?.Identity?.IsAuthenticated == true)
            _navigationManager.NavigateTo("/Appointment", true);
    }
}