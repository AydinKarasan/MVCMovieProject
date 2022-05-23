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
                return new ErrorResult("Girmek istedi�iniz film ad�na sahip kay�t bulunmaktad�r.");
            Film entity = new Film()
            {
                Aciklamasi = model.Aciklamasi?.Trim(),
                Adi = model.Adi.Trim(),
                VizyonTarihi=model.VizyonTarihi,               
                
            };
            Repo.Add(entity);
            return new SuccessResult("��lem ba�ar�l�");
        }

        public Result Delete(int id)
        {
            Film film = Repo.Query(k => k.Id == id, "Filmler").SingleOrDefault();
            if (film.FilmTurler != null && film.FilmTurler.Count > 0)
            {
                return new ErrorResult("Film silinemez ��nk� ili�kili �r�n kay�tlar� bulunmaktad�r!");
            }
            Repo.Delete(film);
            return new SuccessResult("Film ba�ar�yla silindi!");
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
                ImdbPuan�=f.ImdbPuan�
            });
        }

        public Result Update(FilmModel model)
        {
            if (Repo.Query().Any(x => x.Adi.ToLower() == model.Adi.ToLower().Trim() && x.Id != model.Id))
                return new ErrorResult("Girmek istedi�iniz film ad�na sahip kay�t bulunmaktad�r.");

            Film entity = Repo.Query(f => f.Id == model.Id).SingleOrDefault();
            entity.Adi = model.Adi.Trim();
            entity.Aciklamasi = model.Aciklamasi?.Trim();
            entity.VizyonTarihi = model.VizyonTarihi;
            entity.ImdbPuan� = model.ImdbPuan�;

            Repo.Update(entity);
            return new SuccessResult();
        }
    }
}
