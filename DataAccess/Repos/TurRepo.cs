using DataAccess.Contexts;
using DataAccess.Repos.Bases;

namespace DataAccess.Repos
{
    public class TurRepo : TurRepoBase
    {
        public TurRepo() : base ()
        { }
        public TurRepo(MovieProjectContext dbContext) : base(dbContext)
        { }
    }
}
