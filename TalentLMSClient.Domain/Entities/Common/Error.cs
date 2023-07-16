using System.Text.Json.Serialization;

namespace TalentLMSClient.Domain.Entities.Common;

/// <summary>
/// Class that represents an error returned by the API.
/// </summary>
public class Error
{
    /// <summary>
    /// Error code returned by the API.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// Error message returned by the API.
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;

}
