using AppCoreV2.Business.Models;
using AppCoreV2.DataAccess.Entityframework;
using AppCoreV2.DataAccess.Entityframework.Bases;
using Business.Models;
using Business.Services.Bases;
using DataAccess.Contexts;
using DataAccess.Entities;

namespace Business.Services
{
    public class FilmServices : IFilmService
    {
        public RepoBase<Film, MovieProjectContext> Repo { get; set; } = new Repo<Film, MovieProjectContext>();

        public Result Add(FilmModel model)
        {
            if (Repo.Query().Any(x => x.Adi.ToLower() == model.Adi.ToLower().Trim()))
                return new ErrorResult("Girmek istediðiniz film adýna sahip kayýt bulunmaktadýr.");
            Film entity = new Film()
            {
                Aciklamasi = model.Aciklamasi?.Trim(),
                Adi = model.Adi.Trim(),
                VizyonTarihi=model.VizyonTarihi,               
                
            };
            Repo.Add(entity);
            return new SuccessResult("Ýþlem baþarýlý");
        }

        public Result Delete(int id)
        {
            Film film = Repo.Query(k => k.Id == id, "Filmler").SingleOrDefault();
            if (film.FilmTurler != null && film.FilmTurler.Count > 0)
            {
                return new ErrorResult("Film silinemez çünkü iliþkili ürün kayýtlarý bulunmaktadýr!");
            }
            Repo.Delete(film);
            return new SuccessResult("Film baþarýyla silindi!");
        }

        public void Dispose()
        {
            Repo.Dispose();
        }

        public IQueryable<FilmModel> Query()
        {
            return Repo.Query("Filmler").OrderBy(f => f.Adi).Select(f => new FilmModel()
            {
                Aciklamasi = f.Aciklamasi, //AutoMapper ile otomatik yapabilirsin incele
                Adi = f.Adi,
                Id = f.Id,
                VizyonTarihi=f.VizyonTarihi,
                ImdbPuaný=f.ImdbPuaný
            });
        }

        public Result Update(FilmModel model)
        {
            if (Repo.Query().Any(x => x.Adi.ToLower() == model.Adi.ToLower().Trim() && x.Id != model.Id))
                return new ErrorResult("Girmek istediðiniz film adýna sahip kayýt bulunmaktadýr.");

            Film entity = Repo.Query(f => f.Id == model.Id).SingleOrDefault();
            entity.Adi = model.Adi.Trim();
            entity.Aciklamasi = model.Aciklamasi?.Trim();
            entity.VizyonTarihi = model.VizyonTarihi;
            entity.ImdbPuaný = model.ImdbPuaný;

            Repo.Update(entity);
            return new SuccessResult();
        }
    }
}
