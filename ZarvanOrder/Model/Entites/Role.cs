using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace ZarvanOrder.Model.Entites
{
    public class Role : IdentityRole<long>
    {
        public Role()
        {
        }
        public ICollection<RolePermission> RolePermissions { get; set; }
    }
}
