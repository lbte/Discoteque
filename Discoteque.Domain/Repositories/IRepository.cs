namespace Discoteque.Domain.Repositories
{
    using Models;
    using System.Linq.Expressions;

    public interface IRepository<Tid, TEntity>
    where Tid : struct
    where TEntity : BaseEntity<Tid>
    {
        Task AddAsync(TEntity entity);
        Task<TEntity?> FindAsync(Tid id);

        Task<IEnumerable<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        Task<TEntity?> GetEntityAsync(Expression<Func<TEntity, bool>> filter);
        Task Update(TEntity entity);
        void Delete(TEntity entity);
        Task Delete(Tid id);
    }
}
