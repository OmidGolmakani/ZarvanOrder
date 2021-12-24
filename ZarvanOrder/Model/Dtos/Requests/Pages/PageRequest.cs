using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Model.Dtos.Requests.Pages
{
    public class PageRequest : Bases.GetsRequest
    {
        int _pageSize = 0;
        public virtual int PageSize
        {
            set
            {
                this._pageSize = value;
            }
            get
            {
                return this._pageSize > 0 ?
                    this._pageSize :
                    int.MaxValue;

            }
        }
        public virtual int PageIndex { get; set; } = 0;
    }
}
