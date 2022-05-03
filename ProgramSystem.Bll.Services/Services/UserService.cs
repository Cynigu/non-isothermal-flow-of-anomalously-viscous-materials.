using System.Security;
using ProgramSystem.Bll.Services.DTO;
using ProgramSystem.Bll.Services.Interfaces;
using ProgramSystem.Bll.Services.Mapper;
using ProgramSystem.Data.Models;
using ProgramSystem.Data.Repository.Factories;
using ProgramSystem.Data.Repository.UOW;

namespace ProgramSystem.Bll.Services.Services
{
    public class UserService : IUserService
    {
        private readonly ISqlLiteRepositoryContextFactory _contextFactory;
        public UserService(ISqlLiteRepositoryContextFactory sqlLiteRepositoryContextFactory)
        {
            _contextFactory = sqlLiteRepositoryContextFactory;
        }

        public async Task AddUserAsync(UserDTO item)
        {
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                var userEntity = uow.UserRepository.GetEntityQuery().FirstOrDefault(x => x.Login == item.Login);
                if (userEntity != null)
                    throw new Exception("Такой пользователь уже существует");

                await uow.UserRepository.AddAsync(item.ToEntity() ?? throw new InvalidOperationException());
            }
        }

        public async Task UpdateUserAsync(UserDTO item)
        {
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                await uow.UserRepository.UpdateAsync(item.ToEntity());
            }
        }

        public async Task<IEnumerable<UserDTO>> RemoveRangeAsync(int[] ids)
        {
            IEnumerable<UserDTO> deletedUsers;
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                deletedUsers = (await uow.UserRepository.RemoveRangeAsync(x => ids.Contains(x.Id))).Select(x => x.ToDto());
            }

            return deletedUsers;
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            IEnumerable<UserDTO> users;
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                users = uow.UserRepository.GetEntityQuery().Select(x => x.ToDto()).ToList();
            }

            return users;
        }

        public UserDTO? GetAccountByLoginPassword(string login, string password)
        {
            UserDTO? user;
            using var uow = new UnitOfWork(_contextFactory.Create());

            var u= uow.UserRepository.GetEntityQuery().FirstOrDefault(x => x.Login == login && x.Password == password);
            user = u?.ToDto();
            return user;
        }

        public async Task EditUser(string login, string password, int idUser, string role)
        {
            using var uow = new UnitOfWork(_contextFactory.Create());
            await uow.UserRepository.UpdateAsync(new UserEntity()
            {
                Id = idUser,
                Login = login,
                Password = password,
                Role = role
            });
        }
    }
}
