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
    public class ParameterService: IParameterService
    {
        private readonly ISqlLiteRepositoryContextFactory _contextFactory;
        public ParameterService(ISqlLiteRepositoryContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<ICollection<ParameterDTO>> GetAllParametersObjectsByTypeParameterAsync()
        {
            ICollection<ParameterDTO> parameters;
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                var parametersEntities = uow.ParameterRepository.GetEntityQuery();
                parameters = await parametersEntities.Select(x => new ParameterDTO()
                {
                    Id = x.Id,
                    Name = x.Name,
                    TypeParameter = x.TypeParameter,
                    UnitOfMeasName = x.UnitOfMeas.Name
                }).ToListAsync();
            }

            return parameters;
        }

        public async Task<ICollection<ParameterDTO>> GetAllEmpiricalParametersObjectsAsync()
        {
            ICollection<ParameterDTO> parameters;

            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                parameters = await uow.ParameterRepository.GetEntityQuery()
                    .Where(x => x.TypeParameter == "Эмпирический коэффициент математической модели")
                    .Select(x => new ParameterDTO()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        TypeParameter = x.TypeParameter,
                        UnitOfMeasName = x.UnitOfMeas.Name
                    }).ToListAsync();
            }
            return parameters;
        }

        public async Task<ICollection<ParameterDTO>> GetAllMaterialParametersObjectsAsync()
        {
            ICollection<ParameterDTO> parameters;

            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                parameters = await uow.ParameterRepository.GetEntityQuery()
                    .Where(x => x.TypeParameter == "Параметры свойств материала")
                    .Select(x => new ParameterDTO()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        TypeParameter = x.TypeParameter,
                        UnitOfMeasName = x.UnitOfMeas.Name
                    }).ToListAsync();
            }
            return parameters;
        }

        public async Task<ICollection<ParameterDTO>> GetAllParametersObjectsByTypeParameterAsync(string typeParameter)
        {
            ICollection<ParameterDTO> parameters;

            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                parameters = await uow.ParameterRepository.GetEntityQuery()
                    .Where(x => x.TypeParameter == typeParameter)
                    .Select(x => new ParameterDTO()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        TypeParameter = x.TypeParameter,
                        UnitOfMeasName = x.UnitOfMeas.Name
                    }).ToListAsync();
            }
            return parameters;
        }

        public async Task<ICollection<string>> GetAllParameterTypesAsync()
        {
            ICollection<string> types;
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                types = await uow.ParameterRepository.GetEntityQuery()
                    .Select(x => x.TypeParameter)
                    .Distinct()
                    .ToListAsync();
            }

            return types;
        }

        public async Task<ICollection<string>> GetAllParametersNamesAsync()
        {
            ICollection<string> names;
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                names = await uow.ParameterRepository.GetEntityQuery()
                    .Select(x => x.Name)
                    .Distinct()
                    .ToListAsync();
            }

            return names;
        }

        public async Task AddParameterAsync(ParameterDTO parameter)
        {
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                var p = uow.ParameterRepository
                    .GetEntityQuery()
                    .FirstOrDefault(x => x.Name == parameter.Name && x.TypeParameter == parameter.TypeParameter);
                if (p != null)
                {
                    throw new Exception("Такой параметр уже существует!");
                }
                var unitOfMeas = uow.UnitOfMeasRepository
                    .GetEntityQuery()
                    .FirstOrDefault(x => x.Name == parameter.UnitOfMeasName);
                if (unitOfMeas == null)
                {
                    await uow.ParameterRepository.AddAsync(new ParameterEntity()
                    {
                        Name = parameter.Name,
                        TypeParameter = parameter.TypeParameter,
                        UnitOfMeas = new UnitOfMeasEntity(){ Name = parameter.UnitOfMeasName}
                    });
                }
                else
                {
                    await uow.ParameterRepository.AddAsync(new ParameterEntity()
                    {
                        Name = parameter.Name,
                        TypeParameter = parameter.TypeParameter,
                        UnitOfMeasId = unitOfMeas.Id
                    });
                }
            }
        }

        public async Task RemoveParameterByIdAsync(int id)
        {
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                await uow.ParameterRepository.RemoveRangeAsync(x => x.Id == id);
            }
        }
    }
}
