using DataAccess.Contexts;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace MVCMovieProject.Controllers
{
    public class DatabaseController : Controller // örnek veri girişi yapılacak
    {
        public IActionResult Seed()
        {
            using (MovieProjectContext db = new MovieProjectContext())
            {
                var turler = db.Turler.ToList();
                db.Turler.RemoveRange(turler);

                var filmler = db.Filmler.ToList();
                db.Filmler.RemoveRange(filmler);
                
                if (filmler.Count > 0)

                db.Database.ExecuteSqlRaw("dbcc checkident('Filmler',reseed,0)");
                db.Database.ExecuteSqlRaw("dbcc checkident('Filmler',reseed,0)");
                //db işlemleri
                db.Filmler.Add(new Film()
                {
                    Adi = "Yüzüklerin Efendisi",
                    
                });
                db.SaveChanges();
            }
            return Content("<label style=\"color:red;\"><b>İlk Veriller Oluşturuldu</b>", "text/html", Encoding.UTF8);
        }
    }

}

