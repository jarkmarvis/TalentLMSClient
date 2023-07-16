using System.Net;
using System.Text;
using TalentLMSClient.Application.Auth;

namespace TalentLMSClient.Infrastructure.Services.Auth;

public class AuthorizationService : IAuthorizationService
{
    private readonly HttpClient _httpClient;
    private readonly CookieContainer _cookieContainer;
    private bool _isAuthorized;

    public AuthorizationService()
    {
        _cookieContainer = new CookieContainer();
        var handler = new HttpClientHandler
        {
            CookieContainer = _cookieContainer,
            UseCookies = true,
            UseDefaultCredentials = false,
            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
        };

        _httpClient = new HttpClient(handler);
    }

    public async Task<bool> IsAuthorized()
    {
        // Perform cache check
        return _isAuthorized;
    }

    public async Task<bool> Authorize(string username, string password)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "https://api.example.com/auth");
        request.Content = new StringContent($"{{ \"username\": \"{username}\", \"password\": \"{password}\" }}", Encoding.UTF8, "application/json");
        var base64ApiKey = Convert.ToBase64String(Encoding.ASCII.GetBytes("MyApiKey"));
        request.Headers.Add("Authorization", $"Basic {base64ApiKey}");
        var response = await _httpClient.SendAsync(request);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var sessionId = response.Headers.GetValues("Session-Id")?.FirstOrDefault();
            if (!string.IsNullOrEmpty(sessionId))
            {
                var cookie = new Cookie("SessionId", sessionId)
                {
                    Domain = "api.example.com",
                    Path = "/",
                    Expires = DateTime.Now.AddHours(1)
                };

                _cookieContainer.Add(cookie);
                _isAuthorized = true;
                return true;
            }
        }

        return false;
    }
}
