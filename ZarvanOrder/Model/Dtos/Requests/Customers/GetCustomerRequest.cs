﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Model.Dtos.Requests.Customers
{
    public class GetCustomerRequest : Bases.GetRequest
    {
        public long Id { get; set; }
    }
}
