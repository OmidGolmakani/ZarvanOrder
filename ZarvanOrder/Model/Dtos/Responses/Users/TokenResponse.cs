using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ZarvanOrder.Model.Dtos.Responses.Users
{
    public class TokenResponse : Bases.BaseResponse<long>
    {
        [JsonIgnore]
        public override long Id { get => base.Id; set => base.Id = value; }
        public string Value { get; set; }
    }
}
