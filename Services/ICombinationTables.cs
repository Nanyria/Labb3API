namespace Labb3API.Services
{
    public interface ICombinationTables<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetSingleByA(int idA);
        Task<T> GetSingleByB(int idB);
        Task<T> GetSingleByID(int id);

        Task<T> Add(T entity);

        Task<T> Update(T entity);

        Task<T> DeleteByA(int idA);
        Task<T> DeleteByB(int idB);
        Task<T> DeleteByID(int id);
    }
}
