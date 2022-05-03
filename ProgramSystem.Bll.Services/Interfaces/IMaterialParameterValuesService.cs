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
        /// <param name="idParameter"></param>
        /// <param name="idMaterial"></param>
        /// <returns></returns>
        Task DeleteMaterialParameterValue(int idParameter, int idMaterial);

        /// <summary>
        /// Получить свойства материала со значениями которые относятся к выбранному материалу
        /// </summary>
        /// <param name="idMaterial">id материала, для которого нужно получить параметры </param>
        /// <returns></returns>
        Task<ICollection<ParameterValue>> GetAllMaterialParametersValuesByIdMaterialId(int idMaterial);

        /// <summary>
        /// Редактировать эмпирический параметр
        /// </summary>
        /// <param name="parameterId">id параметра</param>
        /// <param name="materialId">id материала</param>
        /// <param name="changingValue">изменяемое значение</param>
        /// <returns></returns>
        Task EditMaterialParameterValue(int parameterId, int materialId, float changingValue);

    }
}
