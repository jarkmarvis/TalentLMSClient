using Microsoft.Extensions.DependencyInjection;
using TalentLMSClient.Application.Courses;
using TalentLMSClient.Infrastructure.Services;

namespace TalentLMSClient.Infrastructure;

/// <summary>
/// Trying this way to add services to the DI container. Not sure which I like better yet.
/// </summary>
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        return services.AddSingleton<ICourseService, CoureseService>();
    }
}
