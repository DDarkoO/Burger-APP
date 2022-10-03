using BurgerApp.DOMAIN.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.VIEWMODELS.BurgerViewModels
{
    public class BurgerViewModel
    {
        public int Id { get; set; }
        [Display(Name = "My name is")]
        public string Name { get; set; }
        [Display(Name = "I cost")]
        public double Price { get; set; }
        [Display(Name = "Am I vegetarian?")]
        public bool IsVegetarian { get; set; }
        [Display(Name = "Am I vegan?")]
        public bool IsVegan { get; set; }
        [Display(Name = "Do I have french-fries?")]
        public bool HasFries { get; set; }
        public List<BurgerOrder> BurgerOrders { get; set; }
    }
}
