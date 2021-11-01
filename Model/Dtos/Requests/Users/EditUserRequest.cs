using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Model.Dtos.Requests.Users
{
    public class EditUserRequest : Bases.EditRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Address { get; set; }
        public string NationalCode { get; set; }
        public bool ImageEdited { get; set; }
        public IFormFile Image { get; set; }
    }
}
