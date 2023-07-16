namespace TalentLMSClient.Application.Auth;

public interface IAuthorizationService
{
    Task<bool> IsAuthorized();

    Task<bool> Authorize(string username, string password);
}
