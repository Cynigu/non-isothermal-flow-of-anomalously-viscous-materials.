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
    /// <param name="parameter"></param>
    /// <returns></returns>
    Task DeleteEmpiricalParameterValue(ParameterValue parameter);

}