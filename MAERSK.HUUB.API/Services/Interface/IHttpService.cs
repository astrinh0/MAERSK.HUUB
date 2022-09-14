using MAERSK.HUUB.DOMAIN.ResponseModels;

namespace MAERSK.HUUB.API.Services
{
    public interface IHttpService
    {
        public Task<List<Order>> RequestOrderApi();
        public Task<List<Delivery>> RequestDeliveryApi();
    }
}
