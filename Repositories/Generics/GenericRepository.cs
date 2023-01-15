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

        public async Task DeleteAsync(string username)
        {
            var entity = await GetAsync(username);
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

        public Task<T> GetAsync<T>(Expression<Func<T, bool>> expression) where T:EntityBase
        {
            return context.Set<T>().Where(expression).FirstOrDefaultAsync();
        }
    }
}
