using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Model.Dtos.Requests.Pages
{
    public class Page
    {
        int _pageSize = 0;
        public int PageSize { 
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
        public int PageIndex { get; set; } = 0;
    }
}
