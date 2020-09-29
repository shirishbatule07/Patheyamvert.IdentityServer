using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer.Storage.Models;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IUserClaimsPrincipalFactory<ApplicationUser> _claimsFactory;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileService(
            IIdentityServerInteractionService interaction,
            IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory,
            IUserStore<ApplicationUser> userStore,
            UserManager<ApplicationUser> userManager
            )
        {
            _claimsFactory = claimsFactory;
            _interaction = interaction;
            _userStore = userStore;
            _userManager = userManager;
        }
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            string sub = context.Subject.GetSubjectId();
            ApplicationUser user = await _userManager.FindByIdAsync(sub).ConfigureAwait(false);
            if (user != null)
            {
                ClaimsPrincipal principal = await _claimsFactory.CreateAsync(user).ConfigureAwait(false);
                List<Claim> claims = principal?.Claims?.ToList();
                claims = claims?.Where(claim => context.RequestedClaimTypes.Contains(claim.Type)).ToList();
                if(claims == null)
                {
                    claims = new List<Claim>();
                }
                claims.Add(new Claim("user_role", user.Role));
                claims.Add(new Claim("name", user.Name));
                claims.Add(new Claim("userid", user.UserId.ToString()));
                context.IssuedClaims = claims;
            }
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var user = await _userManager.FindByIdAsync(context.Subject.GetSubjectId()).ConfigureAwait(false);
            context.IsActive = !(user is null);
            return;
        }
    }
}
