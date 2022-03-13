namespace ProgramSystem.Bll.Services.Interfaces
{
    public interface IBaseService<T>
        where T : class
    {
        Task AddAsync(T item); // добавление объекта
        Task AddRangeAsync(ICollection<T> item); // добавление объекта
        Task UpdateAsync(T item); // обновление объекта
        Task SaveAsync();  // сохранение изменений
        Task<IEnumerable<T>> RemoveRangeAsync(int[] ids); // удаление объекта по id
        IQueryable<T> GetEntityQuery();
    }
}
