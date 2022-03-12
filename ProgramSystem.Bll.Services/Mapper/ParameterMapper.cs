using ProgramSystem.Bll.Services.DTO;
using ProgramSystem.Data.Models;

namespace ProgramSystem.Bll.Services.Mapper;

public static class ParameterMapper
{
    public static MaterialDTO? ToDto(this MaterialEntity entity)
    {
        if (entity == null)
            return null;
        return new MaterialDTO()
        {
            Id = entity.Id,
            Name = entity.Name,
        };
    }

    public static MaterialEntity? ToEntity(this MaterialDTO entity)
    {
        if (entity == null)
            return null;
        return new MaterialEntity()
        {
            Id = entity.Id,
            Name = entity.Name,
        };
    }
}