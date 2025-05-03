
using Data.Models;
using System;

namespace GameShop_V1._0.ViewModels
{
    public class AdminOrderViewModel
    {
        public int OrderId { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }
        public int ProductCount { get; set; }
    }
}
