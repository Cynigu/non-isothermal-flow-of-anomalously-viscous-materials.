using System.ComponentModel.DataAnnotations;

namespace ProgramSystem.Data.Models;

public class ParameterCanalEntity
{
    public int ParameterId { get; set; }
    public ParameterEntity Parameter { get; set; } = null!;

    public int CanalId { get; set; }
    public CanalEntity Canal { get; set; } = null!;

    [Required]
    public float Value { get; set; }
}