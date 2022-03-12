using ProgramSystem.Data.Models;

namespace ProgramSystem.Data.Repository.Interfaces;

public interface IEntityRepository<T> :IBaseRepository<T>
    where T : class, IEntity
{
    
}