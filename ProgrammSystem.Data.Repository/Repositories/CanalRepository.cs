using ProgramSystem.Data.Models;
using ProgramSystem.Data.Repository.Interfaces;

namespace ProgramSystem.Data.Repository.Repositories;

public class CanalRepository : DataBaseRepository<CanalEntity, RepositoryContext>, ICanalRepository
{
    public CanalRepository(RepositoryContext context) : base(context)
    {
    }

}