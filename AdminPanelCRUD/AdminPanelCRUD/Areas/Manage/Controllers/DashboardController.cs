using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanelCRUD.Areas.Manage.Controllers
{
    [Area("Manage")]
    //[Authorize(Roles ="SuperAdmin,Admin")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DashboardController(UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        //public async Task<IActionResult> CreateAdmin()
        //{
        //    AppUser admin = new AppUser
        //    {
        //        FullName = "Kamran Mustafayev",
        //        UserName = "Admin",
        //    };
        //    var result = await _userManager.CreateAsync(admin, "Admin123");
        //    return Ok(result);
        //}

        //public async Task<IActionResult> CreateRole()
        //{
        //    IdentityRole role1 = new IdentityRole("SuperAdmin");
        //    IdentityRole role2 = new IdentityRole("Admin");
        //    IdentityRole role3 = new IdentityRole("Member");

        //   await _roleManager.CreateAsync(role1);
        //   await _roleManager.CreateAsync(role2);
        //   await _roleManager.CreateAsync(role3);

        //    return Ok("Created roles");
        //}

        //public async Task<IActionResult> AddRole()
        //{
        //    AppUser user = await _userManager.FindByNameAsync("Admin");

        //    await _userManager.AddToRoleAsync(user, "Admin");
        //    return Ok("");
        //}
    }
}
