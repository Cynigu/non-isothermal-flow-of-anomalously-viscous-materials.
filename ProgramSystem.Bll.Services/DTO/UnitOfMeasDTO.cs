namespace ProgramSystem.Bll.Services.DTO;

public class UnitOfMeasDTO: IEntityDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    private ICollection<Bll.Services.DTO.ParameterDTO>? Parameters { get; set; }
}