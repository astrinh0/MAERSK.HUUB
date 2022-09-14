using MAERSK.HUUB.DOMAIN.DTO;

namespace MAERSK.HUUB.API.Services
{
    public interface IApiService
    {
        public Task<List<OrderByBrandDTO>> GetOrdersAndDeliveries(int brandId);
        public Task<List<ProductDTO>> GetProductQuantity(int? orderId, string? reference);
    }
}
