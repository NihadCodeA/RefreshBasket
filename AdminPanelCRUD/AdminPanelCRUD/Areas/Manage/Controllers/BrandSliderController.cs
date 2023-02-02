using AdminPanelCRUD.Helpers;
using AdminPanelCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanelCRUD.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class BrandSliderController : Controller
    {
        private readonly PustokContext _pustokContext;
        private readonly IWebHostEnvironment _env;

        public BrandSliderController(PustokContext pustokContext, IWebHostEnvironment env)
        {
            _pustokContext = pustokContext;
            _env = env;
        }
        public IActionResult Index()
        {
            List<BrandSlider> brandSliderList = _pustokContext.BrandSliders.ToList();
            return View(brandSliderList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(BrandSlider brandSlider)
        {
            if (!ModelState.IsValid) return View();

            brandSlider.ImgUrl = FileManager.SaveFile(_env.WebRootPath,"uploads/brandsliders",brandSlider.ImgFile);
            _pustokContext.BrandSliders.Add(brandSlider);
            _pustokContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            BrandSlider brandSlider = _pustokContext.BrandSliders.Find(id);
            if (brandSlider == null) View("Error");
            return View(brandSlider);
        }
        [HttpPost]
        public IActionResult Update(BrandSlider brandSlider)
        {
            BrandSlider existBrandSlider = _pustokContext.BrandSliders.Find(brandSlider.Id);
            if (brandSlider == null) View("Error");
            if (!ModelState.IsValid) return View();
            FileInfo file = new FileInfo(Path.Combine(_env.WebRootPath, "uploads/sliders", existBrandSlider.ImgUrl));
            if (file.Exists)
            {
                file.Delete();
            }

            //-----------------------------------------------------------------------------
            existBrandSlider.ImgUrl = FileManager.SaveFile(_env.WebRootPath, "uploads/slider", brandSlider.ImgFile);
            _pustokContext.SaveChanges();
            return RedirectToAction("Index");
        }

        
        public IActionResult Delete(int id)
        {
            BrandSlider brandSlider = _pustokContext.BrandSliders.Find(id);
            if (brandSlider == null) View("Error");
            return View(brandSlider);
        }
        [HttpPost]
        public IActionResult Delete(BrandSlider brandSlider)
        {
            BrandSlider existBrandSlider = _pustokContext.BrandSliders.Find(brandSlider.Id);
            if (existBrandSlider == null) View("Error");
            FileInfo file = new FileInfo(Path.Combine(_env.WebRootPath, "uploads/sliders", existBrandSlider.ImgUrl));
            if (file.Exists)
            {
                file.Delete();
            }
            _pustokContext.BrandSliders.Remove(existBrandSlider);
            _pustokContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
