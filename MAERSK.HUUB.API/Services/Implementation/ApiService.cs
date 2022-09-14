using MAERSK.HUUB.DOMAIN.DTO;
using MAERSK.HUUB.DOMAIN.ResponseModels;

namespace MAERSK.HUUB.API.Services
{
    public class ApiService : IApiService
    {
        private readonly IHttpService _httpService;

        public ApiService(IHttpService httpService)
        {
          
            _httpService = httpService;

            
        }


        public async Task<List<OrderByBrandDTO>> GetOrdersAndDeliveries(int brandId)
        {

            var orders = await _httpService.RequestOrderApi();

            var deliveries = await _httpService.RequestDeliveryApi();

            var result = new List<OrderByBrandDTO>();


            foreach (var item in  orders)
            {
                if (item.BrandId == brandId)
                {
                    result.Add(new OrderByBrandDTO()
                    {
                        Order = item
                    });
                }
            }

            foreach (var item in deliveries)
            {
                var aux = result.FirstOrDefault(x => x.Order.Id == item.OrderId);

                if (aux != null)
                {
                    aux.Deliveries.Add(item);
                }
            }

            return result;
        }

        public async Task<List<ProductDTO>> GetProductQuantity(int? orderId, string? reference)
        {
            var orders = await _httpService.RequestOrderApi();

            var deliveries = await _httpService.RequestDeliveryApi();

            var result = new List<ProductDTO>();

            var aux = new OrderByBrandDTO() { Order = orders.FirstOrDefault(x => x.Id == orderId || x.Reference == reference)};

            if (aux.Order != null)
            {
                foreach (var item in deliveries)
                {
                    if (item.OrderId == aux.Order.Id)
                    {
                        aux.Deliveries.Add(item);
                    }
                }
            }

            else
            {
                return null;
            }

            foreach (var item in aux.Deliveries)
            {
                if (item.Shipped == true)
                {
                    foreach (var product in item.Products)
                    {
                        var abc = result.FirstOrDefault(x => x.ProductName == product.ProductName);

                        if (abc == null)
                        {
                            result.Add(new ProductDTO() { ProductName = product.ProductName, Quantity = product.Quantity });
                        }
                        else
                        {
                            abc.Quantity += product.Quantity;
                        }
                    }
                }
            }


            return result;
        }

        

    }
}
