using ProgramSystem.Data.Models;
using ProgramSystem.Data.Repository.Interfaces;

namespace ProgramSystem.Data.Repository.Repositories;

public class MaterialRepository : DataBaseRepository<MaterialEntity, RepositoryContext>, IMaterialRepository
{
    public MaterialRepository(RepositoryContext context) : base(context)
    {
    }

}