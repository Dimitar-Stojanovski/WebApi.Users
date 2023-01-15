using AutoMapper;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(string? username)
        {
            if (username==null)
            {
                return null;
            }

            return await context.Set<T>().FindAsync(username);
        }

       
    }
}
