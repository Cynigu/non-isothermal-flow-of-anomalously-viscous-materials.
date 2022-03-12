namespace ProgramSystem.Data.Models;

public class UnitOfMeasEntity: IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    private ICollection<ParameterEntity>? Parameters { get; set; }
}