﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Model.Dtos.Requests.Bases
{
    public class DeleteRequest<TIdentity> : BaseRequest
    {
        public TIdentity Id { get; set; }
    }
}
