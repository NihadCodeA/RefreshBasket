using AdminPanelCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanelCRUD.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class FeatureController : Controller
    {
        private readonly PustokContext _pustokContext;
        public FeatureController(PustokContext pustokContext)
        {
            _pustokContext = pustokContext;
        }
        public IActionResult Index()
        {
            List<Feature> featureList = _pustokContext.Features.ToList();
            return View(featureList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Feature feature)
        {
            _pustokContext.Features.Add(feature);
            _pustokContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Feature feature = _pustokContext.Features.Find(id);
            if (feature == null) View("Error");
            return View(feature);
        }
        [HttpPost]
        public IActionResult Update(Feature feature)
        {
            Feature existFeature = _pustokContext.Features.Find(feature.Id);
            if (feature == null) View("Error");
            existFeature.Icon = feature.Icon;
            existFeature.Header = feature.Header;
            existFeature.About = feature.About;
            _pustokContext.SaveChanges();
            return RedirectToAction("Index");
        }

       

        public IActionResult Delete(int id)
        {
            Feature feature = _pustokContext.Features.Find( id);
            if (feature == null) View("Error");
            return View(feature);
        }
        [HttpPost]
        public IActionResult Delete(Feature feature)
        {
            Feature existFeature = _pustokContext.Features.Find(feature.Id);
            if (existFeature == null) View("Error");
            _pustokContext.Features.Remove(existFeature);
            _pustokContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
