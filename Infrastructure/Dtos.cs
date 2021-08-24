using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RIMOrderManagement.Infrastructure
{
    public record OrderDto(Guid Id, string Address, int OrderItem, DateTimeOffset CreatedDate);
    public record CreateOrderDto([Required] string Address, [Range(0, 1000)] int OrderItem);
    public record UpdateOrderDto([Required] string Address, [Range(0, 1000)] int OrderItem);
}
