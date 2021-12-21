using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Model.Dtos.Responses.Bases
{
    public class BaseResponse<TIdentity>
    {
        public virtual TIdentity Id { get; set; }
    }
}
