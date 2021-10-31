using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Model.Entites
{
    public class RolePermission : AuditDeleteEntity<long>
    {
        public long RoleId { get; set; }
        public string Url { get; set; }
        public string Token { get; set; }
        public Role Role { get; set; }
    }
}
