using ProgramSystem.Data.Models;
using ProgramSystem.Data.Repository.Interfaces;

namespace ProgramSystem.Data.Repository.Repositories;

public class UserRepository : DataBaseRepository<UserEntity, RepositoryContext>, IUserRepository
{
    public UserRepository(RepositoryContext context) : base(context)
    {
    }
}