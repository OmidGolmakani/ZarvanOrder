using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Model.Dtos.Requests.Bases
{
    public class EditRequest<TIdentity> : BaseRequest
    {
        public virtual TIdentity Id { get; set; }
    }
}
