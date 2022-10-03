using BurgerApp.VIEWMODELS.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.SERVICES.Interfaces
{
    public interface IUserService
    {
        List<UserViewModelDD> GetUsersForDD();
    }
}
