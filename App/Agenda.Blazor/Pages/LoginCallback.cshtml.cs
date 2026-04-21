namespace Agenda.Blazor.Pages;

public class LoginCallbackModel : PageModel
{
    public async Task<IActionResult> OnGet(string username, string token, string refreshToken)
    {
        Claim[] claims = [
            new(BlazorConstants.CLAIM_USERNAME, username),
            new(BlazorConstants.CLAIM_TOKEN, token),
            new(BlazorConstants.CLAIM_REFRESHTOKEN, refreshToken)
        ];

        ClaimsIdentity claimsIdentity = new(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        ClaimsPrincipal claimsPrincipal = new(claimsIdentity);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

        return Redirect("/Appointment");
    }
}