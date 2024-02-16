using ssoUM.DAL.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Data;

namespace ssoUM.DAL
{
    public abstract class Repository<T, Tcontext> : IRepository<T> where T : class where Tcontext : DbContext
    {
        protected readonly Tcontext dbContext = null;
        public int pageNumber = -1;
        public int pageSize = -1;

        public Repository(Tcontext context)
        {
            this.dbContext = context;
        }


        public bool IsTransactionRunning()
        {
            return this.dbContext.Database.CurrentTransaction == null ? false : true;
        }
        private IDbContextTransaction BeginTran()
        {
            return this.dbContext.Database.BeginTransaction();
        }
        public IDbContextTransaction BeginTran(IsolationLevel isolationLevel)
        {
            return this.dbContext.Database.BeginTransaction(isolationLevel);
        }



        public IExecutionStrategy GetExecutionStrategy()
        {
            return this.dbContext.Database.CreateExecutionStrategy();
        }


        public IQueryable<T> GetAllByCondition(Expression<Func<T, bool>> condition)
        {
            IQueryable<T> result = this.dbContext.Set<T>();
            if (condition != null)
            {
                if (pageNumber > 0 && pageSize > 0)
                {
                    result = result.Where(condition).Skip((pageNumber - 1) * pageSize).Take(pageSize);
                }
                else
                {
                    result = result.Where(condition);
                }
            }

            return result;
        }

        public async Task<ICollection<T>> GetAllByConditionAsync(Expression<Func<T, bool>> condition)
        {
            IQueryable<T> result = this.dbContext.Set<T>();
            if (condition != null)
            {
                if (pageNumber > 0 && pageSize > 0)
                {
                    result = result.Where(condition).Skip((pageNumber - 1) * pageSize).Take(pageSize);
                }
                else
                {
                    result = result.Where(condition);
                }
            }

            return await result.ToListAsync();
        }

        public IQueryable<T> GetAll()
        {
            IQueryable<T> result;
            if (pageNumber > 0 && pageSize > 0)
            {
                result = this.dbContext.Set<T>().Skip((pageNumber - 1) * pageSize).Take(pageSize);
            }
            else
            {
                result = this.dbContext.Set<T>();
            }
            return result;
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            IQueryable<T> result;
            if (pageNumber > 0 && pageSize > 0)
            {
                result = this.dbContext.Set<T>().Skip((pageNumber - 1) * pageSize).Take(pageSize);
            }
            else
            {
                result = this.dbContext.Set<T>();
            }
            return await result.ToListAsync();
        }

        public T GetSingle(Expression<Func<T, bool>> condition)
        {
            return this.dbContext.Set<T>().Where(condition).FirstOrDefault();
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> condition)
        {
            return await this.dbContext.Set<T>().Where(condition).FirstOrDefaultAsync();
        }


        public async Task<T> GetSingleAysnc(Expression<Func<T, bool>> condition)
        {
            var retValue = await this.dbContext.Set<T>().Where(condition).SingleOrDefaultAsync();

            return retValue;
        }


        public bool Add(T entity)
        {
            this.dbContext.Set<T>().Add(entity);
            return true;
        }
        public bool AddAll(List<T> entityArray)
        {
            foreach (T entity in entityArray)
            {
                dbContext.Set<T>().Add(entity);
            }

            return true;
        }
        public async Task<bool> AddAllAsync(List<T> entityArray)
        {
            foreach (T entity in entityArray)
            {
                await dbContext.Set<T>().AddAsync(entity);
            }

            return true;
        }

        public bool Update(T entity)
        {
            this.dbContext.Entry(entity).State = EntityState.Modified;
            return true;
        }

        public bool Delete(T entity)
        {
            this.dbContext.Set<T>().Remove(entity);
            return true;
        }


        public void SaveChangesManaged()
        {
            this.dbContext.SaveChanges();
        }


        public void setPageNo(int p)
        {
            pageNumber = p;
        }
        public void setPageSize(int p)
        {
            pageSize = p;
        }
    }
}
