using ProgramSystem.Data.Models;
using ProgramSystem.Data.Repository.Interfaces;

namespace ProgramSystem.Data.Repository.Repositories;

public class ParameterRepository : DataBaseRepository<ParameterEntity, RepositoryContext>, IParameterRepository
{
    public ParameterRepository(RepositoryContext context) : base(context)
    {
    }

}