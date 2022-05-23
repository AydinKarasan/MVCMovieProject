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
                return new ErrorResult("Girmek istediðiniz Tür adýna sahip kayýt bulunmaktadýr.");

            Tur entity = new Tur()
            {
                Adi = model.Adi.Trim()
            };
            Repo.Add(entity);
            return new SuccessResult("Ýþlem baþarýlý");
        }

        public Result Delete(int id)
        {
            Tur tur = Repo.Query(k => k.Id == id, "FilmTurler").SingleOrDefault();
            if (tur.FilmTurler != null && tur.FilmTurler.Count > 0)
            {
                return new ErrorResult("Tür silinemez çünkü iliþkili ürün kayýtlarý bulunmaktadýr!");
            }
            Repo.Delete(tur);
            //Repo.Delete(k => k.Id == id);
            return new SuccessResult("Kategori baþarýyla silindi!");
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
                return new ErrorResult("Girmek istediðiniz tür adýna sahip kayýt bulunmaktadýr.");

            Tur entity = Repo.Query(t => t.Id == model.Id).SingleOrDefault();
            entity.Adi = model.Adi.Trim();
            
            Repo.Update(entity);
            return new SuccessResult();
        }
    }
}
