using AppCoreV2.Business.Models;
using Business.Models;
using Business.Services.Bases;
using Microsoft.AspNetCore.Mvc;

namespace MVCMovieProject.Controllers
{
    public class FilmlerController : Controller        
    {
        private readonly IFilmService _filmService;
        public FilmlerController(IFilmService filmService)
        {
            _filmService = filmService;
        }
        public IActionResult Index()
        {
            List<FilmModel> model = _filmService.Query().ToList();
            return View("FilmListesi", model);
        }
        [HttpGet]
        public IActionResult OlusturGetir() 
        {
            return View("OlusturHtml");
        }
        [HttpPost]
        public IActionResult OlusturGonder(string adi, string aciklamasi)
        {
            if (string.IsNullOrWhiteSpace(adi))
                return View("Hata!", "Film adı boş olamaz!");
            if (adi.Trim().Length > 100)
                return View("Hata!", "Film adı maksimum 100 karakter olmalıdır!");
            if (!string.IsNullOrWhiteSpace(aciklamasi) && aciklamasi.Length > 4000)
                return View("Hata!", "Film açıklaması maksimum 4000 karakter olmalıdır!");

            FilmModel model = new FilmModel()
            {
                Aciklamasi = aciklamasi,
                Adi = adi
            };
            Result result = _filmService.Add(model);
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
            FilmModel model = _filmService.Query().SingleOrDefault(x => x.Id == id.Value);
            if (model == null)
            {
                return View("Hata!", "Kayıt bulunamadı!");
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FilmModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _filmService.Update(model);
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
            FilmModel model = _filmService.Query().SingleOrDefault(f => f.Id == id);
            if (model == null)
                return View("Hata!", "Kayıt bulunamadı!");
            return View(model);
        }
        public IActionResult Delete(int? id) //~/Kategoriler/Delete/4
        {
            if (id == null)
                return View("Hata!", "Id gereklidir!");
            var result = _filmService.Delete(id.Value);
            TempData["Mesaj"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
        public IActionResult GetXml()
        {
            string xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
            xml += "<Filmler>";
            List<FilmModel> filmler = _filmService.Query().ToList();
            foreach (FilmModel film in filmler)
            {
                xml += "<Filmler>";
                xml += "<Id>" + film.Id + "</Id>";
                xml += "<Adi>" + film.Adi + "</Adi>";
                xml += "</Filmler>";
            }
            xml += "</Filmler>";
            return Content(xml, "application/xml");
        }

    }
}
