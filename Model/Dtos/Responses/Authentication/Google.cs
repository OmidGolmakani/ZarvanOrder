﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Model.Dtos.Responses.Authentication
{
    public class Google
    {
            public string ClientId { get; set; }
            public string ClientSecret { get; set; }
            public string RedirectUrl { get; set; }
        }
    }
