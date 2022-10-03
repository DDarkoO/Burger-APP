using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.VIEWMODELS.HomeViewModels
{
    public class HomeViewModel
    {
        public string MostPopularBurger { get; set; }
        public int OrdersDone { get; set; }
        public double AverageOrderPrice { get; set; }
    }
}
