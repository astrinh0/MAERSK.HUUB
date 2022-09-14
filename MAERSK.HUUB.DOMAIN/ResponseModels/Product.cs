using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAERSK.HUUB.DOMAIN.ResponseModels
{
    public class Product
    {
        [JsonProperty("product_name")]
        public string ProductName { get; set; }
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}
