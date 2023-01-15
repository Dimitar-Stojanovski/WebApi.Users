using System.Linq.Expressions;
using WebApi.Users.Data.BaseData;

namespace WebApi.Users.Repositories.Generics
{
    public interface IGenericRepository<T>where T : class
    {
        Task<T> GetAsync(string username);
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task DeleteAsync(string username);
        Task<bool>EntityExist<T>(Expression<Func<T,bool>> expression) where T : EntityBase;
        Task<T> GetAsync<T>(Expression<Func<T, bool>> expression) where T:EntityBase;
        
    }
}
