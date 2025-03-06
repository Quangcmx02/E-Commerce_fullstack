using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using AsmC5.Models;

namespace AsmC5.Common.Models
{
    public class ClaimsBuilder
    {
        private readonly List<Claim> _claims = new List<Claim>();
        private readonly ApplicationUser _user;

        public ClaimsBuilder(ApplicationUser user)
        {
            _user = user;
        }

        public ClaimsBuilder AddUsername()
        {
            _claims.Add(new Claim(ClaimTypes.Name, $"{_user.FirstName} {_user.LastName}"));
            return this;
        }

        public ClaimsBuilder AddEmail()
        {
            _claims.Add(new Claim(ClaimTypes.Email, _user.Email));
            return this;
        }

        public ClaimsBuilder AddUserId()
        {
            _claims.Add(new Claim(ClaimTypes.NameIdentifier, _user.Id.ToString()));
            _claims.Add(new Claim("UserId", _user.Id.ToString()));
            return this;
        }

        public ClaimsBuilder AddFirstname()
        {
            _claims.Add(new Claim("Firstname", _user.FirstName));
            return this;
        }

        public ClaimsBuilder AddLastname()
        {
            _claims.Add(new Claim("Lastname", _user.LastName));
            return this;
        }

        public async Task<ClaimsBuilder> AddRolesAsync(UserManager<ApplicationUser> userManager)
        {
            var roles = await userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                _claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return this;
        }

        public List<Claim> Build() => _claims;
    }
}
