using ProgramSystem.Bll.Services.DTO;

namespace ProgramSystem.Bll.Services.Interfaces;

public interface IEmpiricalParameterValuesService
{
    /// <summary>
    /// Получить все эмпирические параметры со значениями для связи (маетриал - параметр)
    /// </summary>
    /// <returns></returns>
    Task<ICollection<ParameterValue>> GetAllEmpiriacalParametrsValues();

    /// <summary>
    /// Добавить эмпирический параметр
    /// </summary>
    /// <param name="parameter"></param>
    /// <returns></returns>
    Task AddEmpiricalParameter(ParameterValue parameter);

    /// <summary>
    /// Удалить эмпирический параметр по объекту
    /// </summary>
    /// <param name="idParameter"></param>
    /// <param name="idMaterial"></param>
    /// <returns></returns>
    Task DeleteEmpiricalParameterValue(int idParameter, int idMaterial);

    /// <summary>
    /// Получить эспирические параметры со значениями которые относятся к выбранному материалу
    /// </summary>
    /// <param name="idMaterial">id материала, для которого нужно получить параметры </param>
    /// <returns></returns>
    Task<ICollection<ParameterValue>> GetEmpiricalParametersValuesByIdMaterialId( int idMaterial );

    /// <summary>
    /// Редактировать эмпирический параметр
    /// </summary>
    /// <param name="parameterId">id параметра</param>
    /// <param name="materialId">id материала</param>
    /// <param name="changingValue">изменяемое значение</param>
    /// <returns></returns>
    Task EditEmpiricalParameterValue(int parameterId, int materialId, float changingValue);

}