using ProgramSystem.Data.Models;
using ProgramSystem.Data.Repository.Interfaces;

namespace ProgramSystem.Data.Repository.Repositories;

public class ParameterMaterialRepository : DataBaseRepository<ParameterMaterialEntity, RepositoryContext>, IParameterMaterialRepository
{
    public ParameterMaterialRepository(RepositoryContext context) : base(context)
    {
    }

}