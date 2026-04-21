namespace Agenda.User.Grpc.ProtoServices;

public class InsertService(ILogger<InsertService> logger, UserDbService userDbService) : Insert.InsertBase
{
    private readonly ILogger<InsertService> _logger = logger;
    private readonly UserDbService _userDbService = userDbService;

    public override async Task<InsertReply> Insert(InsertRequest request, ServerCallContext context)
    {
        _logger.LogInformation(GrpcConstants.SERVICE_INFO, nameof(InsertService));

        Domain.User user = new(0, request.Username, request.Password, (UserRole)request.Role, DateTime.Now);

        InsertResponse insertResponse = await _userDbService.Insert(user);

        return new()
        {
            Id = insertResponse.Id,
            Message = insertResponse.UserResponse.ToString()
        };
    }
}