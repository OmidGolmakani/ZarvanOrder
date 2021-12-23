using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Model.Dtos.Responses.RolePermissions
{
    public class RolePermissionResponse : Bases.BaseResponse<long>
    {
        public string RoleId { get; set; }
        public string Url { get; set; }
        public string Token { get; set; }
        public Roles.RoleResponse Role { get; set; }
    }
}
