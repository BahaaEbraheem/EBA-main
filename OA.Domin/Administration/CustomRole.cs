using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace OA.Domin.Administration
{
    public class CustomRole
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public virtual IEnumerable<PermissionClaim> Claims { get; set; }
    }
}
