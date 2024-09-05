using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Stratosphere.Identity.Services;

public interface IIdentityService
{
    Task AddUserClaims(ClaimsPrincipal? principal, CancellationToken ct = default);
}
