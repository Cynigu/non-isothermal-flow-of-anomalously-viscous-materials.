using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramSystem.Bll.Services.DTO;

namespace ProgramSystem.Bll.Services.Interfaces
{
    public interface IParameterService
    {
        /// <summary>
        /// Получить все параметры (класс включает id, тип параметра, навзание параметра, единица измерения )
        /// </summary>
        /// <returns>Коллекцию материалов с id и наименованиями</returns>
        Task<ICollection<ParameterDTO>> GetAllParametersObjectsAsync();

        /// <summary>
        /// Получить все существующие типы параметров
        /// </summary>
        /// <returns></returns>
        Task<ICollection<string>> GetAllParameterTypesAsync();

        /// <summary>
        /// Получить все существующие наименования параметров
        /// </summary>
        /// <returns></returns>
        Task<ICollection<string>> GetAllParametersNamesAsync();

        /// <summary>
        /// Добавляет параметр
        /// Если наименование единицы измерения еще не существует, то она добавляется
        /// </summary>
        /// <param name="parameter"></param>
        Task AddParameterAsync(ParameterDTO parameter);

        /// <summary>
        /// Удаляет материал по id
        /// </summary>
        /// <param name="id"></param>
        Task RemoveParameterByIdAsync(int id);
    }
}
