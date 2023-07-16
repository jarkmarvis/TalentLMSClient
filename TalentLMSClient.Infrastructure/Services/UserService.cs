using System.Text.Json;
using TalentLMSClient.Domain.Entities;
using TalentLMSClient.Application.Users;
using TalentLMSClient.Domain.Entities.Common;
using TalentLMSClient.Infrastructure.Builders;
using Microsoft.Extensions.Options;

namespace TalentLMSClient.Infrastructure.Services;

/// <summary>
/// Concrete implementation of <see cref="IUserService"/>.
/// </summary>
public class UserService : IUserService
{
    private readonly TalentLMSApiSettings _apiSettings;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="apiSettings"></param>
    public UserService(IOptions<TalentLMSApiSettings> apiSettings)
    {
        _apiSettings = apiSettings.Value;
    }

    //<inheritdoc/>
    public async Task<List<User>> GetUsers()
    {
        var client = new HttpClient();
        var request = new ApiRequestBuilder(_apiSettings, HttpMethod.Get, "users").GetHttpRequestMessage();

        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var users = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<List<User>>(users);
    }
}
