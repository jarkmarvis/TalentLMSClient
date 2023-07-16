using System.Text;
using TalentLMSClient.Domain.Entities.Common;

namespace TalentLMSClient.Infrastructure.Builders;

/// <summary>
/// Generic class used to build an HttpRequestMessage
/// </summary>
public class ApiRequestBuilder
{
    private readonly TalentLMSApiSettings _settings;
    private readonly HttpMethod _method;
    private readonly string _apiRoute;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="settings">TalentLMSApiSettings</param>
    /// <param name="method">HttpMethod</param>
    /// <param name="apiRoute">Route added to the end of the url</param>
    public ApiRequestBuilder(TalentLMSApiSettings settings, HttpMethod method, string apiRoute)
    {
        _settings = settings;
        _method = method;
        _apiRoute = apiRoute;
    }

    /// <summary>
    /// Builds an HttpRequestMessage
    /// </summary>
    /// <returns>HttpRequestMessage</returns>
    public HttpRequestMessage GetHttpRequestMessage()
    {
        var baseUrl = _settings.BaseUrl;
        var apiVersion = _settings.ApiVersion;
        var apiPath = _settings.ApiPath;
        var apiKey = _settings.ApiKey;

        var apiUrl = new Uri($"{baseUrl}/{apiPath}/{apiVersion}/{_apiRoute}");
        var base64ApiKey = Convert.ToBase64String(Encoding.ASCII.GetBytes(apiKey));

        var request = new HttpRequestMessage(_method, $"{apiUrl}");

        request.Headers.Add("Authorization", $"Basic {base64ApiKey}");

        return request;
    }
}
