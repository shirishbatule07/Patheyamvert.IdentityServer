using IdentityServer.Storage;
using IdentityServer.Storage.Models;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public static class IdentityBuilderExtensions
    {
        public static IdentityBuilder AddAspNetUserStore<TUser>(this IdentityBuilder builder)
            where TUser : ApplicationUser
        {
            builder.AddUserStore<UserStore<TUser, IdentityUserClaim<string>>>();
            builder.Services.AddTransient<IUserStore<TUser>, UserStore<TUser, IdentityUserClaim<string>>>();
            return builder;
        }

    }
}
