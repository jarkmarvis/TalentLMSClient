namespace TalentLMSClient.Domain.Entities.Common;

/// <summary>
/// Class for providing TalentLMS API settings from the application settings.
/// </summary>
public class TalentLMSApiSettings
{
    /// <summary>
    /// The base URL for the TalentLMS API implementation.
    /// </summary>
    public string BaseUrl { get; set; } = string.Empty;

    /// <summary>
    /// The TalentLMS API base path (api).
    /// </summary>
    public string ApiPath { get; set; } = string.Empty;

    /// <summary>
    /// The TalentLMS API key.
    /// </summary>
    public string ApiKey { get; set; } = string.Empty;

    /// <summary>
    /// The TalentLMS API version. (Be weary of the version set, it is used in the request path "/api/{version}/...")
    /// </summary>
    public string ApiVersion { get; set; } = string.Empty;
}
