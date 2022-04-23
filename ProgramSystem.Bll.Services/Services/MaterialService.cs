using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProgramSystem.Bll.Services.DTO;
using ProgramSystem.Bll.Services.Interfaces;
using ProgramSystem.Bll.Services.Mapper;
using ProgramSystem.Data.Models;
using ProgramSystem.Data.Repository.Factories;
using ProgramSystem.Data.Repository.UOW;

namespace ProgramSystem.Bll.Services.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly ISqlLiteRepositoryContextFactory _contextFactory;

        public MaterialService(ISqlLiteRepositoryContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<ICollection<string>> GetAllNamesMaterialsAsync()
        {
            ICollection<string> names;
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                var namesFromEntity = uow.MaterialRepository.GetEntityQuery().Select(x => x.Name);
                names = await namesFromEntity.ToListAsync();
            }

            return names;
        }

        public async Task<ICollection<MaterialDTO>> GetAllMaterialsObjectsAsync()
        {
            ICollection<MaterialDTO> materials;
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                var materialsEntities = uow.MaterialRepository.GetEntityQuery();
                materials = await materialsEntities.Select(x => x.ToDto()).ToListAsync();
            }

            return materials;
        }

        public async Task AddMaterialByNameAsync(string name)
        {
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                await uow.MaterialRepository.AddAsync(new MaterialEntity(){Name = name});
            }
        }

        public async Task RemoveMaterialByIdAsync(int id)
        {
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                await uow.MaterialRepository.RemoveRangeAsync(x => x.Id == id);
            }
        }
    }
}
