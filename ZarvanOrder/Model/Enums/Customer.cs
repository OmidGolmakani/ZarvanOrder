using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Model.Enums
{
    internal class Customer
    {
        internal enum CustomerType : byte
        {
            Person = 1,
            Company = 2
        }
    }
}
