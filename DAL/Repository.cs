using ssoUM.DAL.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Data;

namespace ssoUM.DAL
{
    public class Repository<TEntity, Tcontext> : IRepository<TEntity> where TEntity : class where Tcontext : DbContext
    {
        protected readonly Tcontext dbContext;
        public int pageNumber = -1;
        public int pageSize = -1;

        public Repository(Tcontext context)
        {
            dbContext = context;
        }


        public bool IsTransactionRunning()
        {
            return dbContext.Database.CurrentTransaction != null;
        }
        public IDbContextTransaction BeginTran()
        {
            return dbContext.Database.BeginTransaction();
        }
        public IDbContextTransaction BeginTran(IsolationLevel isolationLevel)
        {
            return dbContext.Database.BeginTransaction(isolationLevel);
        }

        public IExecutionStrategy GetExecutionStrategy()
        {
            return dbContext.Database.CreateExecutionStrategy();
        }

        // https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
        public IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbContext.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (pageNumber > 0 && pageSize > 0)
            {
                query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public TEntity GetByID(object id)
        {
            return dbContext.Set<TEntity>().Find(id);
        }


        public IQueryable<TEntity> GetAllByCondition(Expression<Func<TEntity, bool>> condition)
        {
            IQueryable<TEntity> result = dbContext.Set<TEntity>();
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

        public async Task<ICollection<TEntity>> GetAllByConditionAsync(Expression<Func<TEntity, bool>> condition)
        {
            IQueryable<TEntity> result = dbContext.Set<TEntity>();
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

        public IQueryable<TEntity> GetAll()
        {
            IQueryable<TEntity> result;
            if (pageNumber > 0 && pageSize > 0)
            {
                result = dbContext.Set<TEntity>().Skip((pageNumber - 1) * pageSize).Take(pageSize);
            }
            else
            {
                result = dbContext.Set<TEntity>();
            }
            return result;
        }

        public async Task<ICollection<TEntity>> GetAllAsync()
        {
            IQueryable<TEntity> result;
            if (pageNumber > 0 && pageSize > 0)
            {
                result = dbContext.Set<TEntity>().Skip((pageNumber - 1) * pageSize).Take(pageSize);
            }
            else
            {
                result = dbContext.Set<TEntity>();
            }
            return await result.ToListAsync();
        }

        public TEntity GetSingle(Expression<Func<TEntity, bool>> condition)
        {
            return dbContext.Set<TEntity>().Where(condition).SingleOrDefault();
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> condition)
        {
            return await dbContext.Set<TEntity>().Where(condition).FirstOrDefaultAsync();
        }


        public async Task<TEntity> GetSingleAysnc(Expression<Func<TEntity, bool>> condition)
        {
            var retValue = await dbContext.Set<TEntity>().Where(condition).SingleOrDefaultAsync();

            return retValue;
        }


        public void Add(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
        }
        public void AddAll(List<TEntity> entityArray)
        {
            foreach (TEntity entity in entityArray)
            {
                dbContext.Set<TEntity>().Add(entity);
            }
        }
        public async Task AddAllAsync(List<TEntity> entityArray)
        {
            foreach (TEntity entity in entityArray)
            {
                await dbContext.Set<TEntity>().AddAsync(entity);
            }
        }

        public void Update(TEntity entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            if (dbContext.Entry(entity).State == EntityState.Detached)
            {
                dbContext.Set<TEntity>().Attach(entity);
            }
            dbContext.Set<TEntity>().Remove(entity);
        }

        public void Delete(object id)
        {
            TEntity entityToDelete = dbContext.Set<TEntity>().Find(id);
            Delete(entityToDelete);
        }


        public void SaveChangesManaged()
        {
            dbContext.SaveChanges();
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
