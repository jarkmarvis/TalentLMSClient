using Microsoft.Extensions.DependencyInjection;

namespace TalentLMSClient.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        
        services.AddMediatR(new MediatRServiceConfiguration { Lifetime = ServiceLifetime.Transient });

        return services;
            //.AddSingleton(typeof(IPipelineBehavior<,>), typeof(IRequest<T, T>));
            //.AddSingleton(typeof(IPipelineBehavior<,>), typeof(MessageValidatorBehaviour<,>));
    }
}

