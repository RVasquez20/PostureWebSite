using System.Linq.Expressions;

namespace PostureWebSite.Repository
{
    public interface IRepositoryAsync<T> : IDisposable where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetByID(int? id);
        Task<T> Insert(T entity);
        Task<T> Delete(int id);
        Task<T?> Find(Expression<Func<T, bool>> expr);
        Task Update(T entity);
        Task<List<T>?> GetAllWithInlcudes(params Expression<Func<T, object>>[] includes);
    }
}
