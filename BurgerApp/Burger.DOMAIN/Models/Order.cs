
using BurgerApp.DOMAIN.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DOMAIN.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public StoreAddress StoreAddress { get; set; }
        public bool IsDelivered { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public List<BurgerOrder> BurgerOrders { get; set; }

    }
}
