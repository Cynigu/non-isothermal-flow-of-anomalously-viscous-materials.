using Microsoft.EntityFrameworkCore;
using ProgramSystem.Data.Models;
using ProgramSystem.Data.Repository.Interfaces;

namespace ProgramSystem.Data.Repository.Repositories;

public class ParameterCanalMaterialRepository : DataBaseRepository<ParameterMaterialCanalEntity, RepositoryContext>, IParameterCanalMaterialRepository
{
    public ParameterCanalMaterialRepository(RepositoryContext context) : base(context)
    {
    }

}