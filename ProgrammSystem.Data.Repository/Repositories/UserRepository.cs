using System.ComponentModel.DataAnnotations;
using ProgramSystem.Data.Models;
using ProgramSystem.Data.Repository.Interfaces;

namespace ProgramSystem.Data.Repository.Repositories;

public class UserRepository : DataBaseRepository<UserEntity, RepositoryContext>, IUserRepository
{
    public UserRepository(RepositoryContext context) : base(context)
    {
    }

    public override async Task AddAsync(UserEntity item)
    {
        var users = GetEntityQuery().Where(x => x.Login == item.Login);
        if (users.Any())
        {
            throw new ValidationException("Такой логин уже есть");
        }

        await base.AddAsync(item);
    }
}