using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace SpawnCloud.Shared.Web;

public static class AuthorizationExtensions
{
    public static AuthorizationPolicyBuilder RequireScope(this AuthorizationPolicyBuilder builder, params string[] allowedScopes)
    {
        builder.Requirements.Add(new ScopeRequirement(allowedScopes));
        return builder;
    }
    
    public static AuthorizationPolicyBuilder RequireScope(this AuthorizationPolicyBuilder builder, IEnumerable<string> allowedScopes)
    {
        builder.Requirements.Add(new ScopeRequirement(allowedScopes));
        return builder;
    }

    public static IServiceCollection AddSpawnCloudAuthorizationHandlers(this IServiceCollection services)
    {
        services.AddSingleton<IAuthorizationHandler, RequireScopeHandler>();
        return services;
    }
}