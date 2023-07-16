using System.Text.Json.Serialization;

namespace TalentLMSClient.Domain.Entities;

public class Auth
{
    /// <summary>
    /// The user's login name.
    /// </summary>
    [JsonPropertyName("login")]
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// The user's password.
    /// </summary>
    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// The url to redirect the user to after a successful logout.
    /// </summary>
    [JsonPropertyName("logout_redirect")]
    public string LogoutRedirect { get; set; } = string.Empty;
}
