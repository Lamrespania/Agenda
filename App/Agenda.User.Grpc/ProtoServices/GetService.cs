namespace Agenda.User.Grpc.ProtoServices;

public class GetService(ILogger<GetService> logger, UserDbService userDbService) : Get.GetBase
{
    private readonly ILogger<GetService> _logger = logger;
    private readonly UserDbService _userDbService = userDbService;

    public override async Task<GetReply> Get(GetRequest request, ServerCallContext context)
    {
        _logger.LogInformation(GrpcConstants.SERVICE_INFO, nameof(GetService));

        Domain.User user = await _userDbService.Get(request.Id);

        if (user == null)
            return new() { Id = 0 };

        return new()
        {
            Id = user.Id,
            Username = user.Username,
            Password = user.Password,
            Role = (Role)user.Role,
            Created = Timestamp.FromDateTimeOffset(user.Created)
        };
    }
}