namespace Agenda.UI.Common.Services;

public class LoginService(IHttpClientFactory httpClientFactory) : ILoginService
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;

    public async Task<TokenDto> Login(LoginDto loginDto, CancellationToken cancellationToken)
    {
        using HttpClient httpClient = _httpClientFactory.CreateClient();

        using HttpResponseMessage httpResponseMessage = await httpClient.PostAsJsonAsync("/Login", loginDto, cancellationToken);

        httpResponseMessage.EnsureSuccessStatusCode();

        LoginResponseDto loginResponse = await httpResponseMessage.Content.ReadFromJsonAsync<LoginResponseDto>(cancellationToken);

        if (loginResponse.Authorized &&
            string.IsNullOrEmpty(loginResponse.Token) == false &&
            string.IsNullOrEmpty(loginResponse.RefreshToken) == false)
        {
            return new(true, loginResponse.Token, loginResponse.RefreshToken);
        }

        return new(false, null, null);
    }

    public async Task<TokenDto> Refresh(RefreshDto refreshDto, CancellationToken cancellationToken)
    {
        using HttpClient httpClient = _httpClientFactory.CreateClient();

        using HttpResponseMessage httpResponseMessage = await httpClient.PostAsJsonAsync("/Refresh", refreshDto, cancellationToken);

        httpResponseMessage.EnsureSuccessStatusCode();

        RefreshResponseDto refreshResponse = await httpResponseMessage.Content.ReadFromJsonAsync<RefreshResponseDto>(cancellationToken);

        if (refreshResponse.Authorized && string.IsNullOrEmpty(refreshResponse.Token) == false)
            return new(true, refreshResponse.Token, null);

        return new(false, null, null);
    }
}