using Microsoft.EntityFrameworkCore;
using ProgramSystem.Data.Models;
using ProgramSystem.Data.Repository.Interfaces;

namespace ProgramSystem.Data.Repository.Repositories;

public class ParameterCanalMaterialRepository : DataBaseRepository<>
{
    protected readonly RepositoryContext _repositoryContext;
    public ParameterCanalMaterialRepository(RepositoryContext context) 
    {
        _repositoryContext = context;
    }

    public IEnumerable<ParameterMaterialCanalEntity> Get()
    {
        return _repositoryContext.ParameterValues;
    }


    public IEnumerable<ParameterMaterialCanalEntity> Find(Func<ParameterMaterialCanalEntity, bool> predicate)
    {
        return _repositoryContext.ParameterValues.Where(predicate);
    }

    public async Task Add(ParameterMaterialCanalEntity item)
    {
        await _repositoryContext.ParameterValues.AddAsync(item);
        await SaveAsync();
    }

    public async Task Update(ParameterMaterialCanalEntity item)
    {
        _repositoryContext.Entry(item).State = EntityState.Modified;
        await SaveAsync();
    }

    public async Task SaveAsync()
    {
        await _repositoryContext.SaveChangesAsync();
    }


}