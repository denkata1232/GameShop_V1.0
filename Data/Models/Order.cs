
using System;
using System.Collections.Generic;

namespace Data.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }
    }
}
