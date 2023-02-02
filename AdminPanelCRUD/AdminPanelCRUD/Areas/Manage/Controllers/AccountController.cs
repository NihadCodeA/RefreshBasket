using AdminPanelCRUD.Areas.Manage.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanelCRUD.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager ;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginViewModel adminVM)
        {
            if(!ModelState.IsValid) return View();
            AppUser user = await _userManager.FindByNameAsync(adminVM.Username);
            if (user==null)
            {
                ModelState.AddModelError("","Username or Password incorrect");
                return View();
            }
            var result =await _signInManager.PasswordSignInAsync(user,adminVM.Password,false,false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Username or Password incorrect");
                return View();
            }
            return RedirectToAction("index","dashboard");
        }
        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
             await _signInManager.SignOutAsync();
            }
            return RedirectToAction("login","account");
        }
    }
}
