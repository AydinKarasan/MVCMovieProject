using AppCoreV2.DataAccess.Entityframework.Bases;
using DataAccess.Contexts;
using DataAccess.Entities;

namespace DataAccess.Repos.Bases
{
    public class TurRepoBase : RepoBase<Tur, MovieProjectContext >
    {
        protected TurRepoBase() : base()
        { }
        protected TurRepoBase(MovieProjectContext dbContext) : base(dbContext)
        { }
    }
}
