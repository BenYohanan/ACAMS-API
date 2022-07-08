using Core.Model;
using Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.IHelper
{
    public interface IUserHelper
    {
        Task<ApplicationUser> FindByUserNameAsync(string username);

        ApplicationUser FindByUserName(string username);

        string GetCurrentUserId(string username);

        Task<ApplicationUser> FindByEmailAsync(string email);

        Task<ApplicationUser> FindByIdAsync(string id);

        ApplicationUser FindByEmail(string email);

        Task<ApplicationUser> CreateUsersAsync(ApplicationUserViewModel applicationUserViewModel, string profileUrl);

        Task<bool> CheckIfUserIsAdmin(string username);

        string GetValidatedUrl(ApplicationUser user);

        ApplicationUser FindByPhoneNumber(string phoneNumber);

    }
}
