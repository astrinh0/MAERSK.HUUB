using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAERSK.HUUB.DOMAIN.ResponseModels
{
    public class Delivery
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("order_id")]
        public int OrderId { get; set; }
        [JsonProperty("shipped")]
        public bool Shipped { get; set; }
        [JsonProperty("products")]
        public List<Product> Products { get; set; }


        public Delivery()
        {
            Products = new List<Product>();
        }
    }
}
