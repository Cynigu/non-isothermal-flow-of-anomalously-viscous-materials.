using ProgramSystem.Data.Models;
using ProgramSystem.Data.Repository.Interfaces;

namespace ProgramSystem.Data.Repository.Repositories;

public class UnitOfMeasRepository : DataBaseRepository<UnitOfMeasEntity, RepositoryContext>, IUnitOfMeasRepository
{
    public UnitOfMeasRepository(RepositoryContext context) : base(context)
    {
    }

}