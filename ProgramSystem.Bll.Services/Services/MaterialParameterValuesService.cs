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
    public class MaterialParameterValuesService: IMaterialParameterValuesService
    {
        private readonly ISqlLiteRepositoryContextFactory _contextFactory;
        private readonly IParameterService _parameterService;
        private readonly IMaterialService _materialService;
        public MaterialParameterValuesService(ISqlLiteRepositoryContextFactory contextFactory, IParameterService parameterService, IMaterialService materialService)
        {
            _contextFactory = contextFactory;
            _parameterService = parameterService;
            _materialService = materialService;
        }

        public async Task<ICollection<ParameterValue>> GetAllMaterialParametrsValues()
        {
            ICollection<ParameterValue> values;
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                values = await uow.ParameterMaterialRepository.GetEntityQuery()
                    .Select(x => new ParameterValue()
                    {
                        MaterialName = x.Material.Name,
                        ParameterName = x.Parameter.Name,
                        ParameterType = x.Parameter.TypeParameter,
                        UnitOfMeasName = x.Parameter.UnitOfMeas.Name,
                        Value = x.Value
                    }).ToListAsync();
            }

            return values;
        }

        public async Task AddMaterialParameter(ParameterValue parameter)
        {
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                var material = uow.MaterialRepository.GetEntityQuery()
                    .FirstOrDefault(x => x.Name == parameter.MaterialName);
                var param = uow.ParameterRepository.GetEntityQuery()
                    .FirstOrDefault(x =>
                        x.TypeParameter == parameter.ParameterType
                        && x.Name == parameter.ParameterName
                        && x.UnitOfMeas.Name == parameter.UnitOfMeasName);

                if (param == null)
                {
                    await _parameterService.AddParameterAsync(new ParameterDTO()
                    {
                        Name = parameter.ParameterName,
                        TypeParameter = parameter.ParameterType,
                        UnitOfMeasName = parameter.UnitOfMeasName
                    });

                    param = uow.ParameterRepository.GetEntityQuery()
                        .FirstOrDefault(x =>
                            x.TypeParameter == parameter.ParameterType
                            && x.Name == parameter.ParameterName
                            && x.UnitOfMeas.Name == parameter.UnitOfMeasName);
                }
                if (material == null)
                {
                    await _materialService.AddMaterialByNameAsync(parameter.MaterialName);

                    material = uow.MaterialRepository.GetEntityQuery()
                        .FirstOrDefault(x => x.Name == parameter.MaterialName);
                }


                if (material != null && param != null)
                    await uow.ParameterMaterialRepository.AddAsync(new ()
                    {
                        MaterialId = material.Id,
                        ParameterId = param.Id,
                        Value = parameter.Value
                    });
                else
                {
                    throw new Exception("Что-то пошло не так при добавлении!");
                }
            }
        }

        public async Task DeleteMaterialParameterValue(ParameterValue parameter)
        {
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                await uow.ParameterMaterialRepository.RemoveRangeAsync(x =>
                    x.Material.Name == parameter.MaterialName
                    && x.Parameter.Name == parameter.ParameterName
                    && x.Parameter.UnitOfMeas.Name == parameter.UnitOfMeasName);
            }
        }
    }
}
