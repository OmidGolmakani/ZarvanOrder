using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZarvanOrder.Data.DbContext;

namespace ZarvanOrder.Repositores
{
    public class RolePermissionRepository : Repository<Model.Entites.RolePermission>
    {
        public RolePermissionRepository(DbFactory dbFactory, IMapper mapper) : base(dbFactory, mapper)
        {
        }
    }
}
