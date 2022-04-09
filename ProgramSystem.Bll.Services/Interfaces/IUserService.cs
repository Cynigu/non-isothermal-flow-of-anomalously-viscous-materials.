using System.Security;
using ProgramSystem.Bll.Services.DTO;

namespace ProgramSystem.Bll.Services.Interfaces;

public interface IUserService
{
    /// <summary>
    /// Добавить пользователя
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
}