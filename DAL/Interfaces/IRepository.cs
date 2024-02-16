using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Linq.Expressions;

namespace ssoUM.DAL.Interfaces
{
    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> GetAllByCondition(Expression<Func<TEntity, bool>> condition);
        Task<ICollection<TEntity>> GetAllByConditionAsync(Expression<Func<TEntity, bool>> condition);

        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        TEntity GetByID(object id);
        IQueryable<TEntity> GetAll();
        Task<ICollection<TEntity>> GetAllAsync();

        TEntity GetSingle(Expression<Func<TEntity, bool>> condition);

        Task<TEntity> GetSingleAysnc(Expression<Func<TEntity, bool>> condition);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> condition);

        void Add(TEntity entity);
        void AddAll(List<TEntity> entityArray);
        Task AddAllAsync(List<TEntity> entityArray);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(object id);

        void SaveChangesManaged();
        public IExecutionStrategy GetExecutionStrategy();

        void setPageNo(int p);
        void setPageSize(int p);
        IDbContextTransaction BeginTran(IsolationLevel isolationLevel);
    }
}
