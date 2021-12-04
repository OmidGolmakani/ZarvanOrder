using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZarvanOrder.Model.Dtos.Responses.Roles;

namespace ZarvanOrder.Model.Dtos.Requests.RolePermissions
{
    public class GetRolePermissionsRequest
    {
        public string Id { get; set; }
        public string RoleId { get; set; }
        public string Url { get; set; }
        public string Token { get; set; }
    }
}
