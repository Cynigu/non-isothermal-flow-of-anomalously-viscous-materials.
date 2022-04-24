using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramSystem.Bll.Services.DTO;

namespace ProgramSystem.Bll.Services.Interfaces
{
    public interface IMaterialParameterValuesService
    {
        /// <summary>
        /// Получить все параметры свойства материала со значениями для связи (маетриал - параметр)
        /// </summary>
        /// <returns></returns>
        Task<ICollection<ParameterValue>> GetAllMaterialParametrsValues();

        /// <summary>
        /// Добавить свойства материала
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        Task AddMaterialParameter(ParameterValue parameter);

        /// <summary>
        /// Удалить свойства материала параметр по объекту
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        Task DeleteMaterialParameterValue(ParameterValue parameter);

    }
}
