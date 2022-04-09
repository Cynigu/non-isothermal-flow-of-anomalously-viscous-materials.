using System.Security;
using ProgramSystem.Bll.Services.DTO;
using ProgramSystem.Bll.Services.Interfaces;
using ProgramSystem.Bll.Services.Mapper;
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
                await uow.UserRepository.AddAsync(item.ToEntity() ?? throw new InvalidOperationException());
            }
        }

        public async Task AddRangeAsync(ICollection<UserDTO> item)
        {
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                await uow.UserRepository.AddRangeAsync(item.Select(x => x.ToEntity()).ToList());
            }
        }

        public async Task UpdateAsync(UserDTO item)
        {
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                await uow.UserRepository.UpdateAsync(item.ToEntity());
            }
        }

        public async Task SaveAsync()
        {
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                await uow.SaveAsync();
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

        public IQueryable<UserDTO> GetEntityQuery()
        {
            IQueryable<UserDTO> users;
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                users = uow.UserRepository.GetEntityQuery().Select(x => x.ToDto());
            }

            return users;
        }

        public UserDTO? GetAccountByLoginPassword(string login, string password)
        {
            UserDTO? user;
            using var uow = new UnitOfWork(_contextFactory.Create());

            user = uow.UserRepository.GetEntityQuery().FirstOrDefault(x => x.Login == login && x.Password == password).ToDto();

            return user;
        }
    }
}
