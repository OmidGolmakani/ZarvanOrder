﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Model.Dtos.Responses.Users
{
    public class TokenResponse : Bases.BaseResponse
    {
        public string Value { get; set; }
    }
}