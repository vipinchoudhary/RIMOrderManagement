using RIMOrderManagement.Entity;
using RIMOrderManagement.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RIMOrderManagement.Controllers
{
    [ApiController]
    [Route("order")]
    public class OrderController : ControllerBase
    {
        private readonly IRepository<Order> repository;
        public OrderController(IRepository<Order> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAsync([FromQuery]  OrderPaging orderPaging)
        {
            var items = (await repository.GetAllAsync(orderPaging)).Select(a => a.AsDto());
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetByIdAsync(Guid id)
        {
            var item = await repository.GetAsync(id);
            if (item == null)
            {
                NotFound();
            }

            return item.AsDto();
        }

        [HttpPost]
        public async Task<ActionResult<OrderDto>> PostAsync(CreateOrderDto createOrderDto)
        {
            var order = new Order
            {
                Address = createOrderDto.Address,
                OrderItem = createOrderDto.OrderItem,
                CreatedDate = DateTimeOffset.UtcNow,
            };

            await repository.CreateAsync(order);           

            return CreatedAtAction(nameof(GetByIdAsync), new { id = order.Id }, order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, UpdateOrderDto updateItemDto)
        {
            var existingOrder = await repository.GetAsync(id);

            if (existingOrder == null)
            {
                return NotFound();
            }

            existingOrder.Address = updateItemDto.Address;
            existingOrder.OrderItem = updateItemDto.OrderItem;

            await repository.UpdateAsync(existingOrder);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> CancelAsync(Guid id)
        {
            var item = await repository.GetAsync(id);

            if (item == null)
            {
                return NotFound();
            }
            await repository.RemoveAsync(item.Id);
            return NoContent();
        }
    }
}
