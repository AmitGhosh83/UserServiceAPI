using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestService.Models
{
    public class User
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonRequired]
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("password")]

        [JsonRequired]
        public string  Password { get; set; }
        [JsonProperty("created_date")]
        public DateTime CreatedDate { get; set; }

    }
}
