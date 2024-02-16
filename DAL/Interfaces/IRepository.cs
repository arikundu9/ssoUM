using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Linq.Expressions;

namespace ssoUM.DAL.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAllByCondition(Expression<Func<T, bool>> condition);
        Task<ICollection<T>> GetAllByConditionAsync(Expression<Func<T, bool>> condition);

        IQueryable<T> GetAll();
        Task<ICollection<T>> GetAllAsync();

        T GetSingle(Expression<Func<T, bool>> condition);

        Task<T> GetSingleAysnc(Expression<Func<T, bool>> condition);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> condition);

        bool Add(T entity);
        bool AddAll(List<T> entityArray);
        Task<bool> AddAllAsync(List<T> entityArray);
        bool Update(T entity);
        bool Delete(T entity);

        void SaveChangesManaged();
        public IExecutionStrategy GetExecutionStrategy();

        void setPageNo(int p);
        void setPageSize(int p);
        IDbContextTransaction BeginTran(IsolationLevel isolationLevel);
    }
}
