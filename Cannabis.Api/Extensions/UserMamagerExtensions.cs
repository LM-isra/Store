using System.Security.Claims;
using Cannabis.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Cannabis.Api.Extensions;

public static class UserMamagerExtensions
{
    public static async Task<AppUser> FindByUserByClaimsPrincipleWithAddressAsync(this UserManager<AppUser> input, ClaimsPrincipal user)
    {
        var email = user.FindFirstValue(ClaimTypes.Email);
        return await input.Users.Include(x => x.Address).SingleOrDefaultAsync(x => x.Email == email);
    }

    public static async Task<AppUser> FindByEmailFromClaimsPrinciple(this UserManager<AppUser> input, ClaimsPrincipal user)
    {
        var email = user.FindFirstValue(ClaimTypes.Email);
        return await input.Users.SingleOrDefaultAsync(x => x.Email == email);
    }
}