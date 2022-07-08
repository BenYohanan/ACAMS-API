using Core.Db;
using Core.Model;
using Logic.IHelper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Helper
{
    public class EmailHelper: IEmailHelper
    {
        private readonly IUserHelper _userHelper;
        private readonly AppDbContext _context;
        private readonly IGeneralConfiguraion _generalConfiguration;
        public EmailHelper(AppDbContext context, IUserHelper userHelper, IGeneralConfiguraion generalConfiguration)
        {
            _context = context;
           _userHelper = userHelper;
            _generalConfiguration = generalConfiguration;
        }

        public async Task<UserVerification> CreateUserToken(string userEmail)
        {
            try
            {
                var user = await _userHelper.FindByEmailAsync(userEmail);
                if (user != null)
                {
                    UserVerification userVerification = new UserVerification()
                    {
                        UserId = user.Id,
                    };
                    await _context.AddAsync(userVerification);
                    await _context.SaveChangesAsync();
                    return userVerification;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserVerification> GetUserToken(Guid token)
        {
            return await _context.UserVerification.Where(t => t.Used != true && t.Token == token)?.Include(s => s.User).FirstOrDefaultAsync();
        }

        public async Task<bool> MarkTokenAsUsed(UserVerification userVerification)
        {
            try
            {
                var VerifiedUser = _context.UserVerification.Where(s => s.UserId == userVerification.User.Id && s.Used != true).FirstOrDefault();
                if (VerifiedUser != null)
                {
                    userVerification.Used = true;
                    userVerification.DateUsed = DateTime.Now;
                    _context.Update(userVerification);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
