using ProgramSystem.Bll.Services.DTO;
using ProgramSystem.Data.Models;

namespace ProgramSystem.Bll.Services.Mapper;

public static class ParameterMaterialCanalMapper
{
    public static ParameterMaterialCanalDTO? ToDto(this ParameterMaterialCanalEntity entity)
    {
        if (entity == null)
            return null;
        return new ParameterMaterialCanalDTO()
        {
            CanalId = entity.CanalId,
            MaterialId = entity.MaterialId,
            ParameterId = entity.ParameterId,
            Value = entity.Value
        };
    }

    public static ParameterMaterialCanalEntity? ToEntity(this ParameterMaterialCanalDTO entity)
    {
        if (entity == null)
            return null;
        return new ParameterMaterialCanalEntity()
        {
            CanalId = entity.CanalId,
            MaterialId = entity.MaterialId,
            ParameterId = entity.ParameterId,
            Value = entity.Value
        };
    }
}