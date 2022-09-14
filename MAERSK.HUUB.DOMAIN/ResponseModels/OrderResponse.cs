using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAERSK.HUUB.DOMAIN.ResponseModels
{
    public class OrderResponse
    {
        [JsonProperty("data")]
        public List<Order> Orders { get; set; }
    }
}
