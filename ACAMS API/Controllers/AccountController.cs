using ACAMS_API.Model;
using Core.Db;
using Core.Enum;
using Core.Model;
using Core.ViewModel;
using Logic.Helper;
using Logic.IHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACAMS_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : BaseController
    {
        private AppDbContext _context;
        private IDropdownHelper _dropdownHelper;
        private IEmailHelper _emailHelper;
        private IGeneralConfiguraion _generalConfiguration;
        private IUserHelper _userHelper;
        private UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private SignInManager<ApplicationUser> _signInManager;

        public AccountController(AppDbContext context, SignInManager<ApplicationUser> signInManager, IDropdownHelper dropdownHelper, IEmailHelper emailHelper,
            UserManager<ApplicationUser> userManager, IUserHelper userHelper, IWebHostEnvironment webHostEnvironment, IGeneralConfiguraion generalConfiguration)
        {
            _context = context;
            _dropdownHelper = dropdownHelper;
            _emailHelper = emailHelper;
            _userManager = userManager;
            _userHelper = userHelper;
            _userHelper = userHelper;
            _generalConfiguration = generalConfiguration;
            _webHostEnvironment = webHostEnvironment;
            _signInManager = signInManager;
        }

      
    }
}
