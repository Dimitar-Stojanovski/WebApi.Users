namespace WebApi.Users.Repositories.Generics
{
    public interface IGenericRepository<T>where T : class
    {
        Task<T> GetAsync(string? username);
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task DeleteAsync(string username);
        
    }
}
