namespace Agenda.UI.Common.Services;

public class AppointmentService(IHttpClientFactory httpClientFactory) : IAppointmentService
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;

    public string Token { get; set; }

    public async Task<IEnumerable<Appointment>> Get(CancellationToken cancellationToken)
    {
        using HttpClient httpClient = GetHttpClient();

        using HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(
            $"/{CommonConstants.APPOINTMENT}/Get", cancellationToken);

        httpResponseMessage.EnsureSuccessStatusCode();

        IEnumerable<Appointment> response = await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<Appointment>>();

        return response;
    }

    public async Task Insert(Appointment appointment, CancellationToken cancellationToken)
    {
        using HttpClient httpClient = GetHttpClient();

        using HttpResponseMessage httpResponseMessage = await httpClient.PostAsJsonAsync(
            $"/{CommonConstants.APPOINTMENT}/Insert", appointment, cancellationToken);

        httpResponseMessage.EnsureSuccessStatusCode();
    }

    public async Task Update(Appointment appointment, CancellationToken cancellationToken)
    {
        using HttpClient httpClient = GetHttpClient();

        using HttpResponseMessage httpResponseMessage = await httpClient.PutAsJsonAsync(
            $"/{CommonConstants.APPOINTMENT}/Update", appointment, cancellationToken);

        httpResponseMessage.EnsureSuccessStatusCode();
    }

    public async Task Delete(int id, CancellationToken cancellationToken)
    {
        using HttpClient httpClient = GetHttpClient();

        using HttpResponseMessage httpResponseMessage = await httpClient.DeleteAsync(
            $"/{CommonConstants.APPOINTMENT}/Delete/{id}", cancellationToken);

        httpResponseMessage.EnsureSuccessStatusCode();
    }

    private HttpClient GetHttpClient()
    {
        HttpClient httpClient = _httpClientFactory.CreateClient();

        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

        return httpClient;
    }
}