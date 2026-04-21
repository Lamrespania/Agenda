namespace Agenda.Login.Grpc.ProtoServices;

public class LoginService(ILogger<LoginService> logger, UserDbService userDbService, TokenControlDbService tokenControlDbService, TokenService tokenService) : Login.LoginBase
{
    private readonly ILogger<LoginService> _logger = logger;
    private readonly UserDbService _userDbService = userDbService;
    private readonly TokenControlDbService _tokenControlDbService = tokenControlDbService;
    private readonly TokenService _tokenService = tokenService;
    private readonly short _tokenLifetimeMin = short.Parse(Environment.GetEnvironmentVariable(GrpcConstants.USER_TOKEN_LIFETIME_MIN));
    private readonly short _refreshTokenLifetimeHour = short.Parse(Environment.GetEnvironmentVariable(GrpcConstants.USER_TOKEN_REFRESH_LIFETIME_HOUR));

    public override async Task<LoginReply> Login(LoginRequest request, ServerCallContext context)
    {
        _logger.LogInformation(GrpcConstants.SERVICE_INFO, nameof(LoginService));

        LoginReply response = new();

        User user = await _userDbService.Get(request.Username, request.Password);

        if (user != null)
        {
            string token = _tokenService.Generate(user);
            string refreshToken = await InsertRefreshToken(user.Id, token);

            response.Authorized = true;
            response.Token = token;
            response.TokenExpirationMin = _tokenLifetimeMin;
            response.RefreshToken = refreshToken;
            response.RefreshTokenExpirationHour = _refreshTokenLifetimeHour;
        }
        else
        {
            response.Authorized = false;
            response.Token = string.Empty;
            response.TokenExpirationMin = 0;
            response.RefreshToken = string.Empty;
            response.RefreshTokenExpirationHour = 0;
        }

        return response;
    }

    private async Task<string> InsertRefreshToken(int userId, string token)
    {
        string refreshToken = Guid.NewGuid().ToString();

        await _tokenControlDbService.Insert(new(0, userId, token, refreshToken, DateTime.Now.AddHours(_refreshTokenLifetimeHour)));

        return refreshToken;
    }
}