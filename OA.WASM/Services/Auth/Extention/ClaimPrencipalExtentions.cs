using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OA.WASM.Services.Auth.Extention
{
    public static class ClaimPrencipalExtentions
    {

        public static bool HasClaimPremission(this ClaimsPrincipal user, string claimPremission)
        {
            var claims = user?.Claims?.Where(c => c.Type == "Permission" && c.Value == claimPremission);

            return claims != null && claims.Count() > 0;
        }


    }
}
