using AppCoreV2.Business.Models;
using Business.Models;
using Business.Services.Bases;
using Microsoft.AspNetCore.Mvc;

namespace MVCMovieProject.Controllers
{
    public class TurlerController : Controller
    {
        private readonly ITurService _turService;

        public TurlerController(ITurService turService)
        {
            _turService = turService;
        }
        public IActionResult Index()    
        {
            List<TurModel> model = _turService.Query().ToList();
            return View("TurListesi", model);
        }
        [HttpGet]  
        public IActionResult OlusturGetir() 
        {
            return View("OlusturHtml");
        }
        [HttpPost] 
        public IActionResult OlusturGonder(string adi)
        {
            if (string.IsNullOrWhiteSpace(adi))
                return View("Hata!", "Tür adı boş olamaz!");
            if (adi.Trim().Length > 100)
                return View("Hata!", "Tür adı maksimum 100 karakter olmalıdır!");
            
            TurModel model = new TurModel()
            {                
                Adi = adi
            };
            Result result = _turService.Add(model);
            if (result.IsSuccessful)
            {                
                TempData["Mesaj"] = result.Message;
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Mesaj = result.Message;
            return View("Hata!", result.Message);
        }
        public IActionResult Edit(int? id) 
        {            
            if (!id.HasValue)
            {
                return View("Hata", "Id gereklidir!");
            }
            TurModel model = _turService.Query().SingleOrDefault(x => x.Id == id.Value);
            if (model == null)
            {
                return View("Hata!", "Kayıt bulunamadı!");
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TurModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _turService.Update(model);
                if (result.IsSuccessful)
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError("", result.Message);
            }
            return View(model);
        }
        public IActionResult Details(int? id) 
        {
            if (!id.HasValue)
                return View("Hata!", "Id gereklidir!");
            TurModel model = _turService.Query().SingleOrDefault(k => k.Id == id);
            if (model == null)
                return View("Hata!", "Kayıt bulunamadı!");
            return View(model);
        }
        public IActionResult Delete(int? id) 
        {
            if (id == null)
                return View("Hata!", "Id gereklidir!");
            var result = _turService.Delete(id.Value);            
            TempData["Mesaj"] = result.Message;
            return RedirectToAction(nameof(Index));

        }        
        public IActionResult GetXml()
        {
            string xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
            xml += "<Turler>";
            List<TurModel> turler = _turService.Query().ToList();
            foreach (TurModel tur in turler)
            {
                xml += "<Turler>";
                xml += "<Id>" + tur.Id + "</Id>";
                xml += "<Adi>" + tur.Adi + "</Adi>";                
                xml += "</Turler>";
            }
            xml += "</Turler>";
            return Content(xml, "application/xml");
        }

    }
}
