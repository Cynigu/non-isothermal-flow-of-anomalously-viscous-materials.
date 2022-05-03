using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramSystem.Bll.Services.DTO;

namespace ProgramSystem.Bll.Services.Interfaces
{
    public interface IUnitOfMeasService
    {
        /// <summary>
        /// Получить все наименования (описания) ед. измерения
        /// </summary>
        /// <returns>коллекция строк, в которых описания ед. измерений </returns>
        Task<ICollection<string>> GetAllNamseUnitOfMeasAsync();
        /// <summary>
        /// Получить все объекты (с id и описанием) ед. измерений
        /// </summary>
        /// <returns>Коллекцию ед.измерений с id и описанием</returns>
        Task<ICollection<UnitOfMeasDTO>> GetAllUnitOfMeasObjectAsync();

        /// <summary>
        /// Добавляет ед. измерения по описанию,
        /// Есть проверка на существование ед измерения с таким же описанием
        /// </summary>
        /// <param name="description">описание, например: "м/с"</param>
        Task AddUnitOfMeasByDescriptionAsync(string description);

        /// <summary>
        /// Удаляет ед. измерения по id
        /// </summary>
        /// <param name="id"></param>
        Task RemoveUnitOfMeasByIdAsync(int id);

        /// <summary>
        /// Редактировать ед измерения
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        Task EditUnitOfMeas(int id, string name);

    }
}
