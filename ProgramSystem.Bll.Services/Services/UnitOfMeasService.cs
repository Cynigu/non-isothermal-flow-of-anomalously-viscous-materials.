using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProgramSystem.Bll.Services.DTO;
using ProgramSystem.Bll.Services.Interfaces;
using ProgramSystem.Data.Models;
using ProgramSystem.Data.Repository.Factories;
using ProgramSystem.Data.Repository.UOW;

namespace ProgramSystem.Bll.Services.Services
{
    public class UnitOfMeasService: IUnitOfMeasService
    {
        private readonly ISqlLiteRepositoryContextFactory _contextFactory;
        private IUnitOfMeasService _unitOfMeasServiceImplementation;

        public UnitOfMeasService(ISqlLiteRepositoryContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<ICollection<string>> GetAllNamseUnitOfMeasAsync()
        {
            ICollection<string> descriptions;
            using (UnitOfWork uow = new UnitOfWork(_contextFactory.Create()))
            {
                var uoms = uow.UnitOfMeasRepository.GetEntityQuery().Select(x => x.Name);
                descriptions = await uoms.ToListAsync();
            }

            return descriptions;
        }

        public async Task<ICollection<UnitOfMeasDTO>> GetAllUnitOfMeasObjectAsync()
        {
            ICollection<UnitOfMeasDTO> descriptions;
            using (UnitOfWork uow = new UnitOfWork(_contextFactory.Create()))
            {
                var uoms = uow.UnitOfMeasRepository.GetEntityQuery();
                descriptions = await uoms.Select(x => new UnitOfMeasDTO()
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync();
            }

            return descriptions;
        }

        public async Task AddUnitOfMeasByDescriptionAsync(string description)
        {
            var names = await GetAllNamseUnitOfMeasAsync();
            if (names.Contains(description))
            {
                throw new Exception("Такая единица измерения уже существует");
            }
            using (UnitOfWork uow = new UnitOfWork(_contextFactory.Create()))
            {
                await uow.UnitOfMeasRepository.AddAsync(new UnitOfMeasEntity(){Name = description});
            }
        }

        public async Task RemoveUnitOfMeasByIdAsync(int id)
        {
            using (UnitOfWork uow = new UnitOfWork(_contextFactory.Create()))
            {
                await uow.UnitOfMeasRepository.RemoveRangeAsync(x => x.Id == id);
            }
        }

        public async Task EditUnitOfMeas(int id, string name)
        {
            using UnitOfWork uow = new UnitOfWork(_contextFactory.Create());
            await uow.UnitOfMeasRepository.UpdateAsync(new UnitOfMeasEntity()
            {
                Id = id,
                Name = name
            });
        }
    }
}
