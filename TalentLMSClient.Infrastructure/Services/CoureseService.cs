using Microsoft.Extensions.Options;
using System.Text.Json;
using TalentLMSClient.Application.Courses;
using TalentLMSClient.Domain.Entities;
using TalentLMSClient.Domain.Entities.Common;
using TalentLMSClient.Infrastructure.Builders;

namespace TalentLMSClient.Infrastructure.Services;

/// <summary>
/// Concrete implementation of the course service.
/// </summary>
public class CoureseService : ICourseService
{
    private readonly TalentLMSApiSettings _apiSettings;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="apiSettings"></param>
    public CoureseService(IOptions<TalentLMSApiSettings> apiSettings)
    {
        _apiSettings = apiSettings.Value;
    }

    //<inheritdoc/>
    public async Task<List<Course>> GetCourses()
    {
        var client = new HttpClient();
        var request = new ApiRequestBuilder(_apiSettings, HttpMethod.Get, "courses").GetHttpRequestMessage();

        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var courses = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<List<Course>>(courses);
    }
}
