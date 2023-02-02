using Microsoft.AspNetCore.Identity;

namespace AdminPanelCRUD.Areas.Manage.Services
{
    public class LayoutService
    {
		private readonly UserManager<AppUser> _userManager;
		private readonly HttpContextAccessor _httpContextAccessor;
		public LayoutService(UserManager<AppUser> userManager,HttpContextAccessor httpContextAccessor)
		{
			_userManager = userManager;
			_httpContextAccessor = httpContextAccessor;
		}

		public HttpContextAccessor HttpContextAccessor { get; }

		public async Task<AppUser> GetUser()
		{
			AppUser appUser = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name);
			return appUser;
		}
	}
}
