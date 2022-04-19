using System.ComponentModel.DataAnnotations;

namespace ProgramSystem.Data.Models;

public class EmpiricalParameterMaterialEntity
{
    public int ParameterId { get; set; }
    public ParameterEntity Parameter { get; set; } = null!;

    public int MaterialId { get; set; }
    public MaterialEntity Material { get; set; } = null!;

    [Required]
    public float Value { get; set; }
}