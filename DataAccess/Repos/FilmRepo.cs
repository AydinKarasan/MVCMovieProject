using DataAccess.Contexts;
using DataAccess.Repos.Bases;

namespace DataAccess.Repos
{
    public class FilmRepo : FilmRepoBase
    {
        public FilmRepo() : base()
        { 
        }
        public FilmRepo(MovieProjectContext dbContext) : base(dbContext)
        {

        }
    }
}
