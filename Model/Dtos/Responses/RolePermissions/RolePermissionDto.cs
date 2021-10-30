using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Model.Dtos.Responses.RolePermissions
{
    public class RolePermissionDto
    {
        public string Id { get; set; }
        public string RoleId { get; set; }
        public string Url { get; set; }
        public string Token { get; set; }
        public Roles.RoleDto Role { get; set; }
    }
}
