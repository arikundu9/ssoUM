using ssoUM.DAL.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ssoUM.DAL
{
    public abstract class Repository<T, Tcontext> : IRepository<T> where T : class where Tcontext : DbContext
    {
        protected readonly Tcontext ifmsDbContext = null;

        public Repository(Tcontext context)
        {
            this.ifmsDbContext = context;
        }


        public bool IsTransactionRunning()
        {
            return this.ifmsDbContext.Database.CurrentTransaction == null ? false : true;
        }
        private IDbContextTransaction BeginTran()
        {
            return this.ifmsDbContext.Database.BeginTransaction();
        }



        public IExecutionStrategy GetExecutionStrategy()
        {
            return this.ifmsDbContext.Database.CreateExecutionStrategy();
        }


        public IQueryable<T> GetAllByCondition(Expression<Func<T, bool>> condition)
        {
            IQueryable<T> result = this.ifmsDbContext.Set<T>();
            if (condition != null)
            {
                result = result.Where(condition);
            }

            return result;
        }

        public async Task<ICollection<T>> GetAllByConditionAsync(Expression<Func<T, bool>> condition)
        {
            IQueryable<T> result = this.ifmsDbContext.Set<T>();
            if (condition != null)
            {
                result = result.Where(condition);
            }

            return await result.ToListAsync();
        }

        public IQueryable<T> GetAll()
        {
            IQueryable<T> result = this.ifmsDbContext.Set<T>();
            return result;
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            IQueryable<T> result = this.ifmsDbContext.Set<T>();
            return await result.ToListAsync();
        }

        public T GetSingle(Expression<Func<T, bool>> condition)
        {
            return this.ifmsDbContext.Set<T>().Where(condition).FirstOrDefault();
        }
        public async Task<T> GetSingleAysnc(Expression<Func<T, bool>> condition)
        {
            var retValue = await this.ifmsDbContext.Set<T>().Where(condition).SingleOrDefaultAsync();

            return retValue;
        }


        public bool Add(T entity)
        {
            this.ifmsDbContext.Set<T>().Add(entity);
            return true;
        }

        public bool Update(T entity)
        {
            this.ifmsDbContext.Entry(entity).State = EntityState.Modified;
            return true;
        }

        public bool Delete(T entity)
        {
            this.ifmsDbContext.Set<T>().Remove(entity);
            return true;
        }


        public void SaveChangesManaged()
        {
            this.ifmsDbContext.SaveChanges();
        }

    }
}
