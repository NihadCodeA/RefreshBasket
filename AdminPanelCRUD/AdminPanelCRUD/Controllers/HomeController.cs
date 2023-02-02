using AdminPanelCRUD.Models;
using AdminPanelCRUD.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AdminPanelCRUD.Controllers
{
    public class HomeController : Controller
    {
        private readonly PustokContext _pustokContext;
        public HomeController(PustokContext pustokContext)
        {
            _pustokContext = pustokContext;
        }
        public IActionResult Index()
        {
            HomeViewModel model = new HomeViewModel
            {
                Sliders = _pustokContext.Sliders.OrderBy(x=>x.Order).ToList(),
                Features = _pustokContext.Features.ToList(),
                BrandSliders = _pustokContext.BrandSliders.ToList(),
                FeatureBooks=_pustokContext.Books.Where(x=>x.IsFeatured==true).Include(x=>x.Author).Include(x=>x.Genre).Include(x => x.BookImages).ToList(),
                NewBooks=_pustokContext.Books.Where(x=>x.IsNew==true).Include(x=>x.Author).Include(x=>x.Genre).Include(x => x.BookImages).ToList(),
                DiscountedBooks=_pustokContext.Books.Where(x=>x.Discount>0).Include(x=>x.Author).Include(x=>x.Genre).Include(x => x.BookImages).ToList(),
               
            };
            return View(model);
        }

       
    }
}
