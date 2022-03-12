namespace ProgramSystem.Data.Repository.Interfaces
{
    public interface IBaseRepository<T>
        where T : class
    {
        Task Add(T item); // добавление объекта
        Task AddRange(ICollection<T> item); // добавление объекта
        Task Update(T item); // обновление объекта
        Task SaveAsync();  // сохранение изменений
        Task<IEnumerable<T>> DeleteRange(Func<T, bool> predicate); // удаление объекта по id
        IQueryable<T> GetEntityQuery();
    }
}
