using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApi.Users.Data.BaseData;

namespace WebApi.Users.Repositories.Generics
{
    public class GenericRepository<T> :IGenericRepository<T> where T : class
    {
        private readonly UserDbContext context;
        private readonly IMapper mapper;

        public GenericRepository(UserDbContext _context, IMapper mapper)
        {
            context = _context;
            this.mapper = mapper;
        }
        public async Task<T> AddAsync(T entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        

        public async Task DeleteAsync(T entity)
        {
           
            context.Set<T>().Remove(entity);
           await context.SaveChangesAsync();
        }

        public async Task<bool> EntityExist<T1>(Expression<Func<T1, bool>> expression) where T1 : EntityBase
        {
            return await context.Set<T1>().AnyAsync(expression);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(string username)
        {
            if (username==null)
            {
                return null;
            }

            return await context.Set<T>().FindAsync();
        }

        public async Task<T> GetAsync<T>(Expression<Func<T, bool>> expression) where T:EntityBase
        {
            return await context.Set<T>().Where(expression).FirstOrDefaultAsync();
        }

        protected IQueryable<T> QueryByCondition<T>(Expression<Func<T, bool>> expression=null) where T : EntityBase
        {
            var query = context.Set<T>().AsQueryable();

            if (expression!=null)
            {
                query = query.Where(expression);
            }
               
            return query;

        }

        protected async Task UpdateModel<T>(T entity) where T : EntityBase
        {
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
