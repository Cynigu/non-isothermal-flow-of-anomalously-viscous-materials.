using ProgramSystem.Bll.Services.DTO;

namespace ProgramSystem.Bll.Services.Interfaces;

public interface IUserBaseService: IBaseService<UserDTO>
{
    UserDTO? GetAccountByLoginPassword(string login, string password);
}