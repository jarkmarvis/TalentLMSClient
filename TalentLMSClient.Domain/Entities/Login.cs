using System.Text.Json.Serialization;
using TalentLMSClient.Domain.Entities.Common;

namespace TalentLMSClient.Domain.Entities;

public class Login : BaseEntity
{
    /// <summary>
    /// The user's id.
    /// </summary>
    [JsonPropertyName("user_id")]
    public string UserId { get; set; } = string.Empty;
    
    /// <summary>
    /// The login key returned from a successfull auth request.
    /// </summary>
    [JsonPropertyName("login_key")]
    public string LoginKey { get; set; } = string.Empty;
}
