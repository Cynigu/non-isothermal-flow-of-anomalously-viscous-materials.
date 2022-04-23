using ProgramSystem.Data.Models;
using ProgramSystem.Data.Repository.Interfaces;

namespace ProgramSystem.Data.Repository.Repositories;

public class ParameterCanalRepository : DataBaseRepository<ParameterCanalEntity, RepositoryContext>, IParameterCanalRepository
{
    public ParameterCanalRepository(RepositoryContext context) : base(context)
    {
    }

}