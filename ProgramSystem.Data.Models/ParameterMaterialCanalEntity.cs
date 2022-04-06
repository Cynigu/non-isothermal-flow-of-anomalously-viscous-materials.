using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgramSystem.Data.Models;

public class ParameterMaterialCanalEntity
{
    public int ParameterId { get; set; }
    public ParameterEntity Parameter { get; set; } = null!;

    public int MaterialId { get; set; }
    public MaterialEntity Material { get; set; } = null!;

    public int CanalId { get; set; }
    public CanalEntity Canal { get; set; } = null!;

    [Required]
    public float Value { get; set; }
}