using ProgramSystem.Bll.Services.DTO;
using ProgramSystem.Data.Models;

namespace ProgramSystem.Bll.Services.Mapper;

public static class CanalMapper
{
    public static CanalDTO? ToDto(this CanalEntity entity)
    {
        if (entity == null)
            return null;
        return new CanalDTO()
        {
            Id = entity.Id,
            Name = entity.Name,
        };
    }

    public static CanalEntity? ToEntity(this CanalDTO entity)
    {
        if (entity == null)
            return null;

        return new CanalEntity()
        {
            Id = entity.Id,
            Name = entity.Name,
        };
    }
}