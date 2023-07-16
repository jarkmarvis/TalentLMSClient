using System.Text.Json.Serialization;

namespace TalentLMSClient.Domain.Entities;

public class Authenticated
{
    /// <summary>
    /// The user's login name.
    /// </summary>
    [JsonPropertyName("user_id")]
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// The user's password.
    /// </summary>
    [JsonPropertyName("login_key")]
    public string LoginKey { get; set; } = string.Empty;
}
