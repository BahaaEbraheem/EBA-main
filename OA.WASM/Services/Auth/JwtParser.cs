using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace OA.WASM.Services.Auth
{
    public static class JwtParser
    {
        public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var claims = new List<Claim>();
            var payload = jwt.Split('.')[1];

            var jsonBytes = ParseBase64WithoutPadding(payload);

            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            //claims With Same Type there values combined into an array
            //So Split it into multible claims
            claims = ConvertToClaimsList(keyValuePairs);

            return claims;
        }

        private static List<Claim> ConvertToClaimsList(Dictionary<string, object> keyValuePairs)
        {
            var claims = new List<Claim>();
            foreach (var kvp in keyValuePairs)
            {
                if (kvp.Key == "Permission" || kvp.Key == ClaimTypes.Role)
                {
                    var claimVal = kvp.Value.ToString();
                    if (claimVal.Contains("["))
                    {
                        var claimsList = claimVal.Replace("[", string.Empty).Replace("]", string.Empty).Split(",");
                        foreach (var claim in claimsList)
                            claims.Add(new Claim(kvp.Key, claim.Replace("\"", string.Empty)));
                    }
                    else
                        claims.Add(new Claim(kvp.Key, kvp.Value.ToString()));
                }
                else
                    claims.Add(new Claim(kvp.Key, kvp.Value.ToString()));
            }
            return claims;
        }

        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }

    }
}
