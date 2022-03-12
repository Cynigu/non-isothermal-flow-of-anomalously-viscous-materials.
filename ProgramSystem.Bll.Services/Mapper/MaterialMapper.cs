using ProgramSystem.Bll.Services.DTO;
using ProgramSystem.Data.Models;

namespace ProgramSystem.Bll.Services.Mapper;

public static class MaterialMapper
{
    public static MaterialDTO ToDto(this MaterialEntity entity)
    {
        return new MaterialDTO()
        {
            Id = entity.Id,
            Name = entity.Name,
        };
    }

    public static MaterialEntity ToEntity(this MaterialDTO entity)
    {
        return new MaterialEntity()
        {
            Id = entity.Id,
            Name = entity.Name,
        };
    }
}