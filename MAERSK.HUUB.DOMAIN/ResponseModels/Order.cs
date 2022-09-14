using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAERSK.HUUB.DOMAIN.ResponseModels
{
    public class Order
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("brand_id")]
        public int BrandId { get; set; }
        [JsonProperty("customer_name")]
        public string? CustomerName { get; set; }
        [JsonProperty("reference")]
        public string? Reference { get; set; }
        [JsonProperty("order_date")]
        public string OrderDate { get; set; }
        [JsonProperty("price_total")]
        public float PriceTotal { get; set; }
    }
}
