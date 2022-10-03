using BurgerApp.DOMAIN.Enums;
using BurgerApp.DOMAIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.VIEWMODELS.OrderViewModels
{
    public class OrderDetailsViewModel
    {
        public int Id { get; set; }
        public StoreAddress StoreAddress { get; set; }
        public bool IsDelivered { get; set; }
        public PaymentMethod PaymentMethod { get; set; }        
        public string FullName { get; set; }
        public List<string> BurgerNames { get; set; }
        public List<int> BurgerPieces { get; set; }
        public string DeliveryAddress { get; set; }
        public double Price { get; set; }
        public int NumberOfBurgers { get; set; }
        public List<BurgerOrder> BurgerOrders { get; set; }
    }
}
