using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TalentLMSClient.UI.Configuration;

/// <summary>
/// Interface for a service installer.
/// </summary>
public interface IServiceInstaller
{
    void InstallService(IServiceCollection services, IConfiguration configuration);
}
