using TalentLMSClient.Domain.Entities;

namespace TalentLMSClient.Application.Users;

/// <summary>
/// User service.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Get all users in from the api.
    /// </summary>
    /// <returns>List of Users</returns>
    Task<List<User>> GetUsers();
}