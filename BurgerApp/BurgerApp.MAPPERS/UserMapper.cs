using BurgerApp.DOMAIN.Models;
using BurgerApp.VIEWMODELS.UserViewModels;


namespace BurgerApp.MAPPERS
{
    public static class UserMapper
    {
        public static UserViewModelDD ToUserViewModelDD(this User user)
        {
            return new UserViewModelDD
            {
                Id = user.Id,
                FullName = user.FullName
            };
        }
    }
}
