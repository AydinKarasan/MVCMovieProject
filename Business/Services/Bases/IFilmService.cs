using AppCoreV2.Business.Services.Bases;
using Business.Models;
using DataAccess.Contexts;
using DataAccess.Entities;

namespace Business.Services.Bases
{
    public interface IFilmService : IService<FilmModel, Film, MovieProjectContext>
    {
    }
}
