using MAERSK.HUUB.DOMAIN.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAERSK.HUUB.DOMAIN.DTO
{
    public class OrderByBrandDTO
    {
        public Order Order { get; set; }
        public List<Delivery> Deliveries { get; set; }

        public OrderByBrandDTO(Order order, List<Delivery> deliveries)
        {
            Order = order;
            Deliveries = deliveries;
        }

        public OrderByBrandDTO()
        {
            Deliveries = new List<Delivery>();
        }
    }

}
