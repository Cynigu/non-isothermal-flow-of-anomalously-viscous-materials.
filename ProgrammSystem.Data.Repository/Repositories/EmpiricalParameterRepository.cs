using ProgramSystem.Data.Models;
using ProgramSystem.Data.Repository.Interfaces;

namespace ProgramSystem.Data.Repository.Repositories;

public class EmpiricalParameterRepository : DataBaseRepository<EmpiricalParameterMaterialEntity, RepositoryContext>, IEmpiricalParameterRepository
{
    public EmpiricalParameterRepository(RepositoryContext context) : base(context)
    {
    }

}