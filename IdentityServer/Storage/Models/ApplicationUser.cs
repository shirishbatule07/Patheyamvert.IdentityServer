using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;

namespace IdentityServer.Storage.Models
{
    public class ApplicationUser : IdentityUser<string>
    {
        public string SubjectId { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public string Role { get; set; }
        public List<Claim> Claims = new List<Claim>();
    }
}
