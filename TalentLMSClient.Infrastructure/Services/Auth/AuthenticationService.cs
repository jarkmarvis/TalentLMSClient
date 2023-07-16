using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;
using TalentLMSClient.Application.Auth;
using TalentLMSClient.Domain.Entities;

namespace TalentLMSClient.Infrastructure.Services.Auth;

public class AuthenticationService : IAuthenticationService
{
    //need the injected configuration
    private readonly IConfiguration _configuration;

    public AuthenticationService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<Login> Authenticate(string username, string password)
    {
        var client = new HttpClient();
        HttpRequestMessage request = BuildRequest();

        var content = new MultipartFormDataContent();
        content.Add(new StringContent(username), "login");
        content.Add(new StringContent(password), "password");
        content.Add(new StringContent(""), "logout_redirect");
        request.Content = content;

        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();

        return JsonSerializer.Deserialize<Login>(await response.Content.ReadAsStringAsync());

    }

    private HttpRequestMessage BuildRequest()
    {
        var baseUrl = _configuration["BaseUrl"];
        var apiVersion = _configuration["ApiVersion"];
        var apiPath = _configuration["ApiPath"];
        var apiKey = _configuration["ApiKey"];

        var pathSuffix = $"/{apiPath}/{apiVersion}/userlogin";
        var fullUrl = new Uri($"{baseUrl}{pathSuffix}");
        var request = new HttpRequestMessage(HttpMethod.Post, $"{fullUrl}");

        var base64ApiKey = Convert.ToBase64String(Encoding.ASCII.GetBytes(apiKey));

        request.Headers.Add("Authorization", $"Basic {base64ApiKey}");
        var cookieString = $"{Uri.EscapeDataString("cookie-name")}={Uri.EscapeDataString("cookie-value")}; Path=/; Domain=example.com; Expires={DateTimeOffset.Now.AddDays(1):R}; HttpOnly; Secure";

        request.Headers.Add("Cookie", cookieString);
        //request.Headers.Add("Cookie", "AWSALB=" +
        //    "8FhMPysqY9iLEF7NKVLwb9cCiUwWdcAJmOky2F5X9VaDtrLcu9iVyVDU841LkKX4n+0dMm7PHFVg7uDn1NaFl0zXXvyNBboYswo0iOkJ7jSTtA7K80hnwKFZNl9b; " +
        //    "AWSALBCORS=8FhMPysqY9iLEF7NKVLwb9cCiUwWdcAJmOky2F5X9VaDtrLcu9iVyVDU841LkKX4n+0dMm7PHFVg7uDn1NaFl0zXXvyNBboYswo0iOkJ7jSTtA7K80hnwKFZNl9b;" +
        //    " PHPSESSID=elb~u0pn8vm8sssjndj93hveviskpg");
        return request;
    }

    public void SignIn(string username, bool rememberMe)
    {
        throw new NotImplementedException();
    }

    public void SignOut()
    {
        throw new NotImplementedException();
    }
}
