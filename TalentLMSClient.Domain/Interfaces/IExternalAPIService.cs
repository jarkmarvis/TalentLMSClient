namespace TalentLMSClient.Domain.Interfaces;

/// <summary>
/// Provides an abstraction for making requests to external API sources
/// </summary>
public interface IExternalAPIService
{
    /// <summary>
    /// Perform a GET action on the supplied URI
    /// </summary>
    /// <param name="resourceUri">Resource URI</param>
    /// <returns>String response</returns>
    Task<string> GetResource(string resourceUri);

    /// <summary>
    /// Perform a POST action on the supplied URI
    /// </summary>
    /// <param name="resourceUri">Resource URI</param>
    /// <param name="requestBody">Json body of the request</param>
    /// <returns>String response</returns>
    Task<string> PostResource(string resourceUri, string requestBody);
}
