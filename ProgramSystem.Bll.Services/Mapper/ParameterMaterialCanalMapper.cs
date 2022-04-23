using ProgramSystem.Bll.Services.DTO;
using ProgramSystem.Data.Models;

namespace ProgramSystem.Bll.Services.Mapper;

public static class ParameterMaterialCanalMapper
{
    public static ParameterMaterialCanalDTO? ToDto(this VariableParameterMaterialCanalEntity entity)
    {
        if (entity == null)
            return null;
        return new ParameterMaterialCanalDTO()
        {
            CanalId = entity.CanalId,
            MaterialId = entity.MaterialId,
            ParameterId = entity.ParameterId,
            Value = entity.ValueLower
        };
    }

    public static VariableParameterMaterialCanalEntity? ToEntity(this ParameterMaterialCanalDTO entity)
    {
        if (entity == null)
            return null;
        return new VariableParameterMaterialCanalEntity()
        {
            CanalId = entity.CanalId,
            MaterialId = entity.MaterialId,
            ParameterId = entity.ParameterId,
            ValueLower = entity.Value
        };
    }
}