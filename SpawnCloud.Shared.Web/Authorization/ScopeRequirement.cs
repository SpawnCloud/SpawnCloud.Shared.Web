using Microsoft.AspNetCore.Authorization;

namespace SpawnCloud.Shared.Web;

public class ScopeRequirement : IAuthorizationRequirement
{
    public string Scope { get; }

    public ScopeRequirement(string scope)
    {
        Scope = scope;
    }

    public override string ToString()
    {
        return $"ScopeRequirement={Scope}";
    }
}