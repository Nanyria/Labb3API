namespace Labb3API.Services
{
    public interface IPersonAndInterests<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetSingle(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
    }
}
