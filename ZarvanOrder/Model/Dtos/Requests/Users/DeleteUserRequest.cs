using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Model.Dtos.Requests.Users
{
    public class DeleteUserRequest : Bases.DeleteRequest<long>
    {
        public string ReasonDeactivation { get; set; }
    }
}
