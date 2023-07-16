namespace TalentLMSClient.Domain.Entities.Common;

/// <summary>
/// Class to provide common elements for all TLMS api entities.
/// </summary>
public class BaseEntity
{
    /// <summary>
    /// Error returned by the API.
    /// </summary>
    public Error? Error { get; set; }
}
