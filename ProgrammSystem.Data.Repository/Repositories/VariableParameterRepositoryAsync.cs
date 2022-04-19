using Microsoft.EntityFrameworkCore;
using ProgramSystem.Data.Models;
using ProgramSystem.Data.Repository.Interfaces;

namespace ProgramSystem.Data.Repository.Repositories;

public class VariableParameterRepositoryAsync : DataBaseRepository<VariableParameterMaterialCanalEntity, RepositoryContext>, IVariableParameterRepository
{
    public VariableParameterRepositoryAsync(RepositoryContext context) : base(context)
    {
    }

}