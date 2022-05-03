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
    public class EmpiricalParameterValueService: IEmpiricalParameterValuesService
    {
        private readonly ISqlLiteRepositoryContextFactory _contextFactory;
        private readonly IParameterService _parameterService;
        private readonly IMaterialService _materialService;
        public EmpiricalParameterValueService(ISqlLiteRepositoryContextFactory contextFactory, IParameterService parameterService, IMaterialService materialService)
        {
            _contextFactory = contextFactory;
            _parameterService = parameterService;
            _materialService = materialService;
        }

        public async Task<ICollection<ParameterValue>> GetAllEmpiriacalParametrsValues()
        {
            ICollection<ParameterValue> values;
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                values = await uow.EmpiricalParameterRepository.GetEntityQuery()
                    .Select(x => new ParameterValue()
                    {
                        MaterialId = x.MaterialId,
                        ParameterId = x.ParameterId,
                        MaterialName = x.Material.Name,
                        ParameterName = x.Parameter.Name,
                        ParameterType = x.Parameter.TypeParameter,
                        UnitOfMeasName = x.Parameter.UnitOfMeas.Name,
                        Value = x.Value
                    }).ToListAsync();
            }

            return values;
        }

        public async Task AddEmpiricalParameter(ParameterValue parameter)
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
                if ( material == null)
                {
                    await _materialService.AddMaterialByNameAsync(parameter.MaterialName);

                    material = uow.MaterialRepository.GetEntityQuery()
                        .FirstOrDefault(x => x.Name == parameter.MaterialName);
                }


                if (material != null && param != null)
                    await uow.EmpiricalParameterRepository.AddAsync(new EmpiricalParameterMaterialEntity()
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

        public async Task DeleteEmpiricalParameterValue(int idParameter, int idMaterial)
        {
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                await uow.EmpiricalParameterRepository.RemoveRangeAsync(x => 
                    x.MaterialId == idMaterial 
                    && x.ParameterId == idParameter);
            }
        }

        public async Task<ICollection<ParameterValue>> GetEmpiricalParametersValuesByIdMaterialId(int idMaterial)
        {
            using var uow = new UnitOfWork(_contextFactory.Create());
            ICollection<ParameterValue> parameters = await uow.EmpiricalParameterRepository.GetEntityQuery()
                .Where(x => x.MaterialId == idMaterial)
                .Select(y => new ParameterValue()
                {
                    ParameterId = y.ParameterId,
                    MaterialId = y.MaterialId,
                    ParameterName = y.Parameter.Name,
                    MaterialName = y.Material.Name,
                    ParameterType = y.Parameter.TypeParameter,
                    UnitOfMeasName = y.Parameter.UnitOfMeas.Name,
                    Value = y.Value,
                }).ToListAsync();
            return parameters;
        }

        public async Task EditEmpiricalParameterValue(int parameterId, int materialId, float changingValue)
        {
            using var uow = new UnitOfWork(_contextFactory.Create());
            var parameter = await uow.EmpiricalParameterRepository.GetEntityQuery()
                .FirstOrDefaultAsync(x => x.MaterialId == materialId && x.ParameterId == parameterId);
            if (parameter == null)
                throw new Exception("Параметр-значение соотвествующий материлом и параметром не найден");
            parameter.Value = changingValue;
            await uow.EmpiricalParameterRepository.UpdateAsync(parameter);
        }
    }
}
