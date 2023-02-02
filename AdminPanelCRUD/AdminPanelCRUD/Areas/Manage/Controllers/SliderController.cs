using AdminPanelCRUD.Helpers;
using AdminPanelCRUD.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace AdminPanelCRUD.Areas.Manage.Controllers
{
    [Area("Manage")]
    //[Authorize(Roles ="SuperAdmin")]
    public class SliderController : Controller
    {
        private readonly PustokContext _pustokContext;
        private readonly IWebHostEnvironment _env;
        public SliderController(PustokContext pustokContext,IWebHostEnvironment env)
        {
            _pustokContext = pustokContext;
            _env=env;
        }
        public IActionResult Index()
        {
            List<Slider> sliderList = _pustokContext.Sliders.ToList();
            return View(sliderList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Slider slider)
        {
            if (!ModelState.IsValid) return View();
            if (slider.ImgFile != null)
            {
                if (slider.ImgFile.ContentType != "image/png" && slider.ImgFile.ContentType != "image/jpg")
                {
                    ModelState.AddModelError("ImgFile", "Ancaq png ve jpg(jpeg) ola biler!");
                    return View();
                }
            }
            slider.ImgUrl = FileManager.SaveFile(_env.WebRootPath,"uploads/sliders",slider.ImgFile);
            _pustokContext.Sliders.Add(slider);
            _pustokContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Slider slider = _pustokContext.Sliders.Find(id);
            if (slider == null) View("Error");
            return View(slider);
        }
        [HttpPost]
        public IActionResult Update(Slider slider)
        {
            Slider existSlider = _pustokContext.Sliders.Find(slider.Id);
            if (slider == null) View("Error");
            if (!ModelState.IsValid) return View();
            if (slider.ImgUrl!=null)
            {
                FileInfo file = new FileInfo(Path.Combine(_env.WebRootPath, "uploads/sliders", existSlider.ImgUrl));
                if (file.Exists)
                {
                    file.Delete();
                }
                //-----------------------------------------------------------------------------
                existSlider.ImgUrl = FileManager.SaveFile(_env.WebRootPath,"uploads/sliders",slider.ImgFile);
            }
            existSlider.FirstTitle = slider.FirstTitle;
            existSlider.SecondTitle = slider.SecondTitle;
            existSlider.Description = slider.Description;
            existSlider.RedirectUrl = slider.RedirectUrl;
            existSlider.RedirectUrlText = slider.RedirectUrlText;
            existSlider.Order = slider.Order;
            _pustokContext.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            Slider slider = _pustokContext.Sliders.Find(id);
            if (slider == null) NotFound(); //404
            if (slider.ImgUrl!=null)
            {
                FileManager.DeleteFile(_env.WebRootPath, "uploads/sliders", slider.ImgUrl);
            }
            _pustokContext.Sliders.Remove(slider);
            _pustokContext.SaveChanges();
            return Ok(); //200
            //return View(slider);
        }
        
    }
}
