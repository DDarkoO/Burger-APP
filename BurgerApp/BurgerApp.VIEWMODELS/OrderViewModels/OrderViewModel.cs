using BurgerApp.DOMAIN.Enums;
using BurgerApp.DOMAIN.Models;
using System.ComponentModel.DataAnnotations;

namespace BurgerApp.VIEWMODELS.OrderViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Payment method")]
        public PaymentMethod PaymentMethod { get; set; }
        [Display(Name = "Is the order delivered?")]
        public bool IsDelivered { get; set; }
        [Display(Name = "Burger shop address")]
        public StoreAddress StoreAddress { get; set; }
        public int UserId {get; set; }
        [Display(Name = "How many pieces would you like to order?")]
        public int NumberOfBurgers { get; set; }
        [Display(Name = "Select a burger from the menu")]
        public List<string> BurgerNames { get; set; }
        [Display(Name = "Select the burger's size")]
        public List<BurgerSize> BurgerSizes { get; set; }
        public List<BurgerOrder> BurgerOrders { get; set; }
    }
}
