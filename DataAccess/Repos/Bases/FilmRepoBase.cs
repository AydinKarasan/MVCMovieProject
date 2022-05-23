
using AppCoreV2.DataAccess.Entityframework.Bases;
using DataAccess.Contexts;
using DataAccess.Entities;

namespace DataAccess.Repos.Bases
{
    public abstract class FilmRepoBase : RepoBase<Film, MovieProjectContext>
    {
        protected FilmRepoBase() : base()
        {

        }
        protected FilmRepoBase(MovieProjectContext dbContext) : base(dbContext)
        {

        }
    }
}
