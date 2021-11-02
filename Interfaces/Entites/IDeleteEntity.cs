using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Interfaces.Entites
{
    public interface IDeleteEntity
    {
      bool IsDeleted { get; set; }
       DateTime? DeletedDate { get; set; }
       string DeletedBy { get; set; }
    }
}
