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
        Task<ICollection<ParameterDTO>> GetAllParametersObjectsByTypeParameterAsync();

        /// <summary>
        /// Получить все эмпирические параметры
        /// </summary>
        /// <returns>Коллекцию параметрво</returns>
        Task<ICollection<ParameterDTO>> GetAllEmpiricalParametersObjectsAsync();

        /// <summary>
        /// Получить все параметры материала
        /// </summary>
        /// <returns>Коллекцию параметров</returns>
        Task<ICollection<ParameterDTO>> GetAllMaterialParametersObjectsAsync();

        /// <summary>
        /// Получить параметры по типу параметра
        /// </summary>
        /// <param name="typeParameter">тип параметра:
        /// Геометрические параметры канала,
        /// Параметры свойств материала,
        /// Режимные параметры процесса,
        /// Эмпирические коэффициенты математической модели</param>
        /// <returns></returns>
        Task<ICollection<ParameterDTO>> GetAllParametersObjectsByTypeParameterAsync(string typeParameter);

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
        /// <summary>
        /// Редактировать параметр 
        /// </summary>
        /// <param name="idParameter"></param>
        /// <param name="typeParameter"></param>
        /// <param name="name"></param>
        /// <param name="unitOfMeasId"></param>
        /// <returns></returns>

        Task EditParameter(int idParameter, string typeParameter, string name, int unitOfMeasId);
    }
}
