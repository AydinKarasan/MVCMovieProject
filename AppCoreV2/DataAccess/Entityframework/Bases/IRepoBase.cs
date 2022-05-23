using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AppCoreV2.DataAccess.Entityframework.Bases
{
    public interface IRepoBase<TEntity, TDbContext> : IDisposable where TEntity : class, new() where TDbContext : DbContext, new()
    {
        //CRUD
        TDbContext DbContext { get; set; }
        IQueryable<TEntity> Query(params string[] entitiesToInclude);//Read  
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate, params string[] entitiesToInclude); 

        void Add(TEntity entity, bool save = true); // Create
        void Update(TEntity entity, bool save = true); // Update
        void Delete(TEntity entity, bool save = true); // Delete
        void Delete(Expression<Func<TEntity, bool>> predicate, bool save = true);
        int Save();
    }
}
