namespace ProgramSystem.Data.Repository.Interfaces
{
    public interface IBaseRepository<T>
        where T : class
    {
        IEnumerable<T> Get(); // получение всех объектов
        IEnumerable<T> Find(Func<T, bool> predicate); // получение одного объекта по id
        Task Add(T item); // добавление объекта
        Task AddRange(ICollection<T> item); // добавление объекта
        Task Update(T item); // обновление объекта
        Task SaveAsync();  // сохранение изменений
        Task<IEnumerable<T>> DeleteRange(Func<T, bool> predicate); // удаление объекта по id
        IQueryable<T> GetEntityQuery();
    }
}
