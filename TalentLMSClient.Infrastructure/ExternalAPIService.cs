using TalentLMSClient.Domain.Interfaces;

namespace TalentLMSClient.Infrastructure;

public class ExternalAPIService : IExternalAPIService
{
    private readonly HttpClient _httpClient;

    public Task<string> GetResource(string resourceUri)
    {
        throw new NotImplementedException();
    }

    public Task<string> PostResource(string resourceUri, string requestBody)
    {
        throw new NotImplementedException();
    }
}
