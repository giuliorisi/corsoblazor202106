// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityProvider.Models;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityProvider
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                new IdentityResources.OpenId(),
                new ProfileWithRoleidentityResource(),
                new IdentityResources.Email()
                   };
        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[] {
            new ApiScope("meteoapi", "La mia Weather API")
            };
       

        public static IEnumerable<ApiResource> Apis() =>
            new ApiResource[] 
            {
                new ApiResource("meteoapi", "La mia API meteo", 
                    userClaims: new[] { JwtClaimTypes.Role })
                {
                    Scopes = {"meteoapi" },
                   
                }
            };



    public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "blazor",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,
                    AllowedCorsOrigins = {"https://localhost:5001" },
                    AllowedScopes = { "openid", "profile", "email", "meteoapi"},
                    RedirectUris = { "https://localhost:5001/authentication/login-callback"  },
                    PostLogoutRedirectUris = {"https://localhost:5001/" },
                    Enabled = true
                }
            };
    }
}