using IdentityModel;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityProvider.Models
{
    public class ProfileWithRoleidentityResource: IdentityResources.Profile
    {
        public ProfileWithRoleidentityResource()
        {
            this.UserClaims.Add(JwtClaimTypes.Role);
        }
    }
}
