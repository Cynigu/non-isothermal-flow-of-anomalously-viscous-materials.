﻿using ProgramSystem.Bll.Services.DTO;

namespace ProgramSystem.Bll.Services.Interfaces
{
    public interface IBaseService<T>
        where T : class, IEntityDTO
    {
        IEnumerable<T> Get(); // получение всех объектов
        Task<T> Get(int id); // получение одного объекта по id
        Task<IEnumerable<T>> Get(int[] ids); // получение одного объекта по id
        Task Add(T item); // добавление объекта
        Task Update(T item); // обновление объекта
        Task<T> Delete(int id); // удаление объекта по id
        Task SaveAsync();  // сохранение изменений
    }

    public interface IUserBaseService: IBaseService<UserDTO>
    {

    }
}
