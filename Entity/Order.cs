using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RIMOrderManagement.Entity
{
    public class Order : IEntity
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public int OrderItem { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}
