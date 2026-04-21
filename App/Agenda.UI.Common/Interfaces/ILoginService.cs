namespace Agenda.UI.Common.Interfaces;

public interface ILoginService
{
    Task<TokenDto> Login(LoginDto loginDto, CancellationToken cancellationToken);
    Task<TokenDto> Refresh(RefreshDto refreshDto, CancellationToken cancellationToken);
}