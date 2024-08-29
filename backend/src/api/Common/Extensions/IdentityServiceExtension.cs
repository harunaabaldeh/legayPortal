using api.Common.Services;
using api.Entities;

namespace api.Common.Extensions;

public static class IdentityServiceExtension
{
    public static void IdentityServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddIdentityCore<AppUser>(o =>
        {
            o.Password.RequireNonAlphanumeric = false;
        });

        builder.Services.AddScoped<TokenService>();
    }
}