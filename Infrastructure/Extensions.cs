using RIMOrderManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RIMOrderManagement.Infrastructure
{
    public static class Extensions
    {
        public static OrderDto AsDto(this Order order)
        {
            return new OrderDto(order.Id, order.Address, order.OrderItem, order.CreatedDate);
        }
    }
}
