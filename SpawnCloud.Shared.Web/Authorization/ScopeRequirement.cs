using Microsoft.AspNetCore.Authorization;

namespace SpawnCloud.Shared.Web;

public class ScopeRequirement : IAuthorizationRequirement
{
    public IEnumerable<string> AllowedScopes { get; }

    public ScopeRequirement(IEnumerable<string>? allowedScopes)
    {
        AllowedScopes = allowedScopes ?? Enumerable.Empty<string>();
    }

    public override string ToString()
    {
        return $"ScopeRequirement={string.Join(',', AllowedScopes)}";
    }
}