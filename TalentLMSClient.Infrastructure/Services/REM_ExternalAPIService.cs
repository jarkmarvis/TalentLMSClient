using TalentLMSClient.Domain.Interfaces;

namespace TalentLMSClient.Infrastructure.Services;

//TODO: Remove this class 

public class REM_ExternalAPIService : REM_IExternalAPIService
{
    private readonly HttpClient _httpClient;

    public REM_ExternalAPIService()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://api.example.com");
    }

    public async Task<string> GetResource(string resourceUri)
    {
        HttpResponseMessage response = await _httpClient.GetAsync(resourceUri);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> PostResource(string resourceUri, string requestBody)
    {
        HttpResponseMessage response = await _httpClient.PostAsync(resourceUri, new StringContent(requestBody));
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }
}
