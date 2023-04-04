namespace CleanMinimalAPIDemo.Domain.Services.Interfaces;

public interface IRepositoryService<T> where T : class
{
    Task<T?> GetAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    T UpdateAsync(T entity);
    T DeleteAsync(T entity);
}