namespace ProgramSystem.Bll.Services.DTO;

public class UnitOfMeasDTO
{
    /// <summary>
    /// ID не обязательно при создании нового объекта
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Наименование
    /// </summary>
    public string Name { get; set; } = null!;
    private ICollection<Bll.Services.DTO.ParameterDTO>? Parameters { get; set; }
}