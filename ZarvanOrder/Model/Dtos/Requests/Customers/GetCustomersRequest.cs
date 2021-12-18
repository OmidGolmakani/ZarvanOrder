﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Model.Dtos.Requests.Customers
{
    public class GetCustomersRequest : Bases.GetsRequest
    {
        public long RefId { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; }
        public byte CustomerType { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string CompanyName { get; set; }
    }
}
