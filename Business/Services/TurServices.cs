using AppCoreV2.Business.Models;
using AppCoreV2.DataAccess.Entityframework;
using AppCoreV2.DataAccess.Entityframework.Bases;
using Business.Models;
using Business.Services.Bases;
using DataAccess.Contexts;
using DataAccess.Entities;

namespace Business.Services
{
    public class TurServices : ITurService
    {
        public RepoBase<Tur, MovieProjectContext> Repo { get; set; } = new Repo<Tur, MovieProjectContext>();

        public Result Add(TurModel model)
        {
            if (Repo.Query().Any(x => x.Adi.ToLower() == model.Adi.ToLower().Trim()))
                return new ErrorResult("Girmek istedi�iniz T�r ad�na sahip kay�t bulunmaktad�r.");

            Tur entity = new Tur()
            {
                Adi = model.Adi.Trim()
            };
            Repo.Add(entity);
            return new SuccessResult("��lem ba�ar�l�");
        }

        public Result Delete(int id)
        {
            Tur tur = Repo.Query(k => k.Id == id, "FilmTurler").SingleOrDefault();
            if (tur.FilmTurler != null && tur.FilmTurler.Count > 0)
            {
                return new ErrorResult("T�r silinemez ��nk� ili�kili �r�n kay�tlar� bulunmaktad�r!");
            }
            Repo.Delete(tur);
            //Repo.Delete(k => k.Id == id);
            return new SuccessResult("Kategori ba�ar�yla silindi!");
        }

        public void Dispose()
        {
            Repo.Dispose();
        }        
        public IQueryable<TurModel> Query()
        {
            return Repo.Query("FilmTurler").OrderBy(t => t.Adi).Select(t => new TurModel()
            {                
                Adi = t.Adi,
                Id = t.Id,                
            });
        }
        public Result Update(TurModel model)
        {
            if (Repo.Query().Any(x => x.Adi.ToLower() == model.Adi.ToLower().Trim() && x.Id != model.Id))
                return new ErrorResult("Girmek istedi�iniz t�r ad�na sahip kay�t bulunmaktad�r.");

            Tur entity = Repo.Query(t => t.Id == model.Id).SingleOrDefault();
            entity.Adi = model.Adi.Trim();
            
            Repo.Update(entity);
            return new SuccessResult();
        }
    }
}
