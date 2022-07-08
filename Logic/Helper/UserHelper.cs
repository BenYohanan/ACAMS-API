using Core.Db;
using Core.Model;
using Core.ViewModel;
using Logic.IHelper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Helper
{
    public class UserHelper : IUserHelper
    {
        private AppDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private readonly IGeneralConfiguraion _generalConfiguration;

        public UserHelper(AppDbContext context, UserManager<ApplicationUser> userManager, IGeneralConfiguraion generalConfiguration)
        {
            _context = context;
            _userManager = userManager;
            _generalConfiguration = generalConfiguration;
        }

        public async Task<ApplicationUser> FindByUserNameAsync(string username)
        {
            return await _userManager.Users.Where(s => s.UserName == username)?.FirstOrDefaultAsync();
        }

        public ApplicationUser FindByUserName(string username)
        {
            return _userManager.Users.Where(s => s.UserName == username)?.FirstOrDefault();
        }

        public string GetCurrentUserId(string username)
        {
            return _userManager.Users.Where(s => s.UserName == username)?.FirstOrDefaultAsync().Result.Id?.ToString();
        }

        public async Task<ApplicationUser> FindByEmailAsync(string email)
        {
            return await _userManager.Users.Where(s => s.Email == email)?.Include(x => x.Gender).Include(s => s.Religion)
                    .Include(x => x.Nationality).Include(x => x.School).Include(x => x.State).FirstOrDefaultAsync();
        }

        public async Task<ApplicationUser> FindByIdAsync(string id)
        {
            return await _userManager.Users.Where(s => s.Id == id).Include(x => x.Gender).Include(s => s.State)
                    .Include(x => x.Religion).Include(x => x.Nationality).Include(x => x.School).FirstOrDefaultAsync();
        }

        public ApplicationUser FindByEmail(string email)
        {
            var user = _userManager.Users.Where(s => s.Email == email)?.Include(x => x.Gender).Include(s => s.Religion)
                    .Include(x => x.Nationality).Include(x => x.School).Include(x => x.State).FirstOrDefault();
            if (user == null)
            {
                return null;
            }
            else
            {
                return user;
            }
        }

        public async Task<ApplicationUser> CreateUsersAsync(ApplicationUserViewModel applicationUserViewModel, string profileUrl)
        {
            try
            {
                if (applicationUserViewModel.Email != null && applicationUserViewModel.FirstName != null)
                {
                    var applicationUser = new ApplicationUser()
                    {
                        UserName = applicationUserViewModel.Email,
                        FirstName = applicationUserViewModel.FirstName,
                        LastName = applicationUserViewModel.LastName,
                        MiddleName = applicationUserViewModel.MiddleName,
                        Password = applicationUserViewModel.Password,
                        ConfirmPassword = applicationUserViewModel.ConfirmPassword,
                        Email = applicationUserViewModel.Email,
                        DateOfBirth = applicationUserViewModel.DateOfBirth,
                        Deactivated = false,
                        PhoneNumber = applicationUserViewModel.PhoneNumber,
                        GenderId = applicationUserViewModel.GenderId,
                    };
                    if (applicationUser.Email != null && applicationUser.Password != null)
                    {
                        applicationUser.DateRegistered = DateTime.Now;
                        var result = await _userManager.CreateAsync(applicationUser, applicationUserViewModel.Password);
                        if (result.Succeeded)
                        {
                            return applicationUser;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> CheckIfUserIsAdmin(string username)
        {
            try
            {
                if (username == null)
                {
                    return false;
                }
                var currentUser = FindByUserNameAsync(username);
                var userDetails = await _userManager.Users.Where(s => s.UserName == currentUser.Result.UserName)?.FirstOrDefaultAsync();
                if (userDetails != null)
                {
                    var goAdmin = await _userManager.IsInRoleAsync(userDetails, "SuperAdmin");
                    if (goAdmin)
                    {
                        return goAdmin;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public string GetValidatedUrl(ApplicationUser user)
        {
            var isUserAnAdmin = _userManager.IsInRoleAsync(user, "SuperAdmin").Result;
            if(isUserAnAdmin)
            {
                return "/Admin/AdminIndex";
            }
            else
            {
                return "/User/UserIndex";
            }
        }

        public ApplicationUser FindByPhoneNumber(string phoneNumber)
        {
            var user = _userManager.Users.Where(p => p.PhoneNumber == phoneNumber).Include(x => x.Gender).Include(x => x.Religion)
                    .Include(x => x.School).Include(x => x.Nationality).Include(x => x.State).FirstOrDefault();
            if (user == null)
            {
                return null;
            }
            else
            {
                return user;
            }
        }
    }
}
