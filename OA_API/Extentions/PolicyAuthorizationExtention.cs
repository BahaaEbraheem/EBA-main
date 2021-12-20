using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace OA_API.Extentions
{
    public static class PolicyAuthorizationExtention
    {

        public static IServiceCollection AddPolicyBasedAuthorization(this IServiceCollection services)
        {

            services.AddAuthorizationCore(options => {

                options.AddPolicy("COM_ADM-control", policy => policy.RequireAssertion(context => AdminOrCan(context, "COM_ADM-control")));



                options.AddPolicy("administration-roles", policy => policy.RequireAssertion(context => AdminOrCan(context, "administration-roles")));
                options.AddPolicy("administration-users", policy => policy.RequireAssertion(context => AdminOrCan(context, "administration-users")));
                options.AddPolicy("app-settings-control", policy => policy.RequireAssertion(context => AdminOrCan(context, "app-settings-control")));
                options.AddPolicy("audeting-access", policy => policy.RequireAssertion(context => AdminOrCan(context, "audeting-access")));
                options.AddPolicy("error-log-access", policy => policy.RequireAssertion(context => AdminOrCan(context, "error-log-access")));
                options.AddPolicy("push-notification-control", policy => policy.RequireAssertion(context => AdminOrCan(context, "push-notification-control")));
                options.AddPolicy("reporting-control", policy => policy.RequireAssertion(context => AdminOrCan(context, "reporting-control")));
                options.AddPolicy("indexes-control", policy => policy.RequireAssertion(context => AdminOrCan(context, "indexes-control")));

                options.AddPolicy("menues-control", policy => policy.RequireAssertion(context => AdminOrCan(context, "menues-control")));
                options.AddPolicy("blocks-control", policy => policy.RequireAssertion(context => AdminOrCan(context, "blocks-control")));
                options.AddPolicy("pages-control", policy => policy.RequireAssertion(context => AdminOrCan(context, "pages-control")));
                options.AddPolicy("events-control", policy => policy.RequireAssertion(context => AdminOrCan(context, "events-control")));
                options.AddPolicy("news-control", policy => policy.RequireAssertion(context => AdminOrCan(context, "news-control")));
                options.AddPolicy("articles-control", policy => policy.RequireAssertion(context => AdminOrCan(context, "articles-control")));
                options.AddPolicy("attachments-control", policy => policy.RequireAssertion(context => AdminOrCan(context, "attachments-control")));
            
                
                
                
                options.AddPolicy("people-control", policy => policy.RequireAssertion(context => AdminOrCan(context, "People-control")));



            });

            return services;
        }

        public static bool AdminOrCan(AuthorizationHandlerContext context, string claim)
        {
            bool isAdmin = context.User.IsInRole("Admin");
            bool can = context.User.HasClaim("Permission", claim);

            return isAdmin || can;
        }
        public static bool AdminOrCan(AuthorizationHandlerContext context, List<string> claims)
        {
            bool isAdmin = context.User.IsInRole("Admin");
           
            foreach (string c in claims)
                if (context.User.HasClaim("Permission", c))
                    return true;

            return isAdmin;

        }

        public static bool Can(AuthorizationHandlerContext context, string claim)
        {
            return context.User.HasClaim("Permission", claim);
        }

        public static bool Can(AuthorizationHandlerContext context, List<string> claims)
        {
            foreach (string c in claims)
                if (context.User.HasClaim("Permission", c))
                    return true;            

            return false;
        }

    }
}
