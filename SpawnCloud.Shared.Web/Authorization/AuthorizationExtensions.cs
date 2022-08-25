using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace SpawnCloud.Shared.Web;

public static class AuthorizationExtensions
{
    public static AuthorizationPolicyBuilder RequireScope(this AuthorizationPolicyBuilder builder, string scope)
    {
        builder.Requirements.Add(new ScopeRequirement(scope));
        return builder;
    }

    public static IServiceCollection AddSpawnCloudAuthorizationHandlers(this IServiceCollection services)
    {
        services.AddSingleton<IAuthorizationHandler, RequireScopeHandler>();
        return services;
    }
}