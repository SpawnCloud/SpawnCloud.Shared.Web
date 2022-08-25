using Microsoft.AspNetCore.Authorization;

namespace SpawnCloud.Shared.Web;

public class RequireScopeHandler : AuthorizationHandler<ScopeRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ScopeRequirement requirement)
    {
        var hasScope = context.User.FindFirst(Claims.Scope)?.Value
            .Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Contains(requirement.Scope) ?? false;
        
        if (hasScope)
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}
