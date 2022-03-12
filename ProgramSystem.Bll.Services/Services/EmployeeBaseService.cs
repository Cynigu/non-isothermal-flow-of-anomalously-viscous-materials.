using ProgramSystem.Bll.Services.DTO;
using ProgramSystem.Bll.Services.Interfaces;
using ProgramSystem.Data.Repository.Factories;
using ProgramSystem.Data.Repository.UOW;

namespace ProgramSystem.Bll.Services.Services
{
    //public class UserBaseService : IUserBaseService
    //{
    //    private readonly IRepositoryContextFactory _contextFactory;
    //    public UserBaseService(IRepositoryContextFactory repositoryContextFactory)
    //    {
    //        _contextFactory = repositoryContextFactory;
    //    }

    //    public async Task Add(UserDTO item)
    //    {
    //        using (var uow = new UnitOfWork(_contextFactory.Create()))
    //        {
    //            await uow.UserRepository.Add(item.ToEntity());
    //        }
    //    }

    //    public async Task<EmployeeDTO> Delete(int id)
    //    {
    //        Employee emp;
    //        using (var uow = new UnitOfWork(_contextFactory.Create()))
    //        {
    //            emp = await uow.EmployeeRepository.Delete(id);
    //        }
    //        return emp.ToDTO();

    //    }

    //    public IEnumerable<EmployeeDTO> Get()
    //    {
    //        IEnumerable<Employee> emp;
    //        using (var uow = new UnitOfWork(_contextFactory.Create()))
    //        {
    //            emp = uow.EmployeeRepository.Get().ToList();
    //        }
    //        return emp.Select(x=>x.ToDTO());
    //    }

    //    public async Task<EmployeeDTO> Get(int id)
    //    {
    //        Employee emp;
    //        using (var uow = new UnitOfWork(_contextFactory.Create()))
    //        {
    //            emp = await uow.EmployeeRepository.Get(id);
    //        }
    //        return emp.ToDTO();
    //    }

    //    public async Task<IEnumerable<EmployeeDTO>> Get(int[] ids)
    //    {
    //        IEnumerable<Employee> emp;
    //        using (var uow = new UnitOfWork(_contextFactory.Create()))
    //        {
    //            emp = await uow.EmployeeRepository.Get(ids);
    //        }
    //        return emp.Select(x => x.ToDTO());
    //    }

    //    public async Task SaveAsync()
    //    {
    //        using (var uow = new UnitOfWork(_contextFactory.Create()))
    //        {
    //            await uow.SaveAsync();
    //        }
    //    }

    //    public async Task Update(EmployeeDTO item)
    //    {
    //        using (var uow = new UnitOfWork(_contextFactory.Create()))
    //        {
    //            await uow.EmployeeRepository.Update(item.ToEntity());
    //        }
    //    }
    //}
}
