namespace Agenda.Login.Grpc.ProtoServices;

public class RefreshService(ILogger<RefreshService> logger, UserDbService userDbService,
    TokenControlDbService tokenControlDbService, TokenService tokenService) : Refresh.RefreshBase
{
    private readonly ILogger<RefreshService> _logger = logger;
    private readonly UserDbService _userDbService = userDbService;
    private readonly TokenControlDbService _tokenControlDbService = tokenControlDbService;
    private readonly TokenService _tokenService = tokenService;
    private readonly short _tokenLifetimeMin = short.Parse(Environment.GetEnvironmentVariable(GrpcConstants.USER_TOKEN_LIFETIME_MIN));

    public override async Task<RefreshReply> Refresh(RefreshRequest request, ServerCallContext context)
    {
        _logger.LogInformation(GrpcConstants.SERVICE_INFO, nameof(RefreshService));

        User user = await _userDbService.Get(request.Username);

        if (user == null)
            return GetEmptyResponse();

        TokenControl tokenControl = await _tokenControlDbService.Get(user.Id, request.RefreshToken);

        if (tokenControl == null || tokenControl.RefreshTokenExpiringDate < DateTime.Now)
            return GetEmptyResponse();

        string token = _tokenService.Generate(user);

        await UpdateRefreshToken(tokenControl, token);

        return new()
        {
            Authorized = true,
            Token = token,
            TokenLifetimeMin = _tokenLifetimeMin
        };
    }

    private RefreshReply GetEmptyResponse()
    {
        return new()
        {
            Authorized = false,
            Token = string.Empty,
            TokenLifetimeMin = 0
        };
    }

    private async Task UpdateRefreshToken(TokenControl tokenControl, string token)
    {
        await _tokenControlDbService.Update(tokenControl.Id, token, tokenControl.RefreshToken, tokenControl.RefreshTokenExpiringDate);
    }
}