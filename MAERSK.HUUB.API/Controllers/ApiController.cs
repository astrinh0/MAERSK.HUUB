using MAERSK.HUUB.API.Services;
using MAERSK.HUUB.DOMAIN.DTO;
using Microsoft.AspNetCore.Mvc;

namespace MAERSK.HUUB.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {

        private readonly IApiService _apiService;
        private readonly ILogger<ApiController> _logger;

        public ApiController(ILogger<ApiController> logger, IApiService apiService)
        {
            _logger = logger;
            _apiService = apiService;
        }

        [HttpGet]
        [Route("GetOrdersAndDeliveries")]
        public async Task<List<OrderByBrandDTO>> GetOrdersAndDeliveries(int brandId)
        {

            var aux = await _apiService.GetOrdersAndDeliveries(brandId);
            return aux;
        }

        [HttpGet]
        [Route("GetProductQuantity")]
        public async Task<List<ProductDTO>> GetProductQuantity(int? orderId, string? reference)
        {

            var aux = await _apiService.GetProductQuantity(orderId, reference);
            return aux;
        }
    }
}