using TalentLMSClient.Domain.Entities;

namespace TalentLMSClient.Application.Auth;

/// <summary>
/// Authentication service
/// </summary>
public interface IAuthenticationService
{
    //TODO: Incomplete
    /// <summary>
    /// Authenticate a user
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    Task<Login> Authenticate(string username, string password);

    void SignIn(string username, bool rememberMe);

    void SignOut();
}
