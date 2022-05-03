using System.Security;
using ProgramSystem.Bll.Services.DTO;

namespace ProgramSystem.Bll.Services.Interfaces;

public interface IUserService
{
    /// <summary>
    /// Получить список всех пользователей
    /// </summary>
    /// <returns></returns>
    IEnumerable<UserDTO> GetAllUsers();

    /// <summary>
    /// Удалить несколько пользователей (можно и одного) по id
    /// </summary>
    /// <param name="ids"></param>
    /// <returns>Возвращает данные удаленных пользователей</returns>
    Task<IEnumerable<UserDTO>> RemoveRangeAsync(int[] ids);

    /// <summary>
    /// Изменить данные пользователя (Id обязательно)
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    Task UpdateUserAsync(UserDTO item);

    /// <summary>
    /// Добавить пользователя (Id не обязательно)
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    Task AddUserAsync(UserDTO item);

    /// <summary>
    /// Получить данные аккаунта (id, роль, логин, пароль) по логину, паролю 
    /// </summary>
    /// <param name="login"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    UserDTO? GetAccountByLoginPassword(string login, string password);

    /// <summary>
    /// Редактировать пользователя
    /// </summary>
    /// <param name="login"></param>
    /// <param name="password"></param>
    /// <param name="idUser"></param>
    /// <param name="role"></param>
    /// <returns></returns>
    Task EditUser(string login, string password, int idUser, string role);
}