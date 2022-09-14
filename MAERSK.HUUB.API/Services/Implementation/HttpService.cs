using MAERSK.HUUB.DOMAIN.ResponseModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MAERSK.HUUB.API.Services
{
    public class HttpService : IHttpService
    {
        private readonly IHttpClientFactory _client;
        private readonly IConfiguration _configuration;

        public HttpService(IHttpClientFactory client, IConfiguration configuration)
        {
            _client = client;
            _configuration = configuration;
        }

        public async Task<List<Order>> RequestOrderApi()
        {

            var result = new List<Order>();

            var url =
                $"{_configuration.GetValue<string>("AmazonApiOrders")}";

            using (var request = _client.CreateClient())
            {
                var response = await request.GetAsync(url);

                if (response != null && response.IsSuccessStatusCode)
                {
                    var model = JsonConvert.DeserializeObject<OrderResponse>(await response.Content.ReadAsStringAsync());

                    result = model.Orders;

                    return result;
                }


                return null;
            }

        }

        public async Task<List<Delivery>> RequestDeliveryApi()
        {

            var result = new List<Delivery>();

            var url =
                $"{_configuration.GetValue<string>("AmazonApiDeliveries")}";

            using (var request = _client.CreateClient())
            {
                var response = await request.GetAsync(url);

                if (response != null && response.IsSuccessStatusCode)
                {
                    var model = JsonConvert.DeserializeObject<DeliveryResponse>(await response.Content.ReadAsStringAsync());

                    result = model.Deliveries;

                    return result;
                }


                return null;
            }

        }
    }
}
