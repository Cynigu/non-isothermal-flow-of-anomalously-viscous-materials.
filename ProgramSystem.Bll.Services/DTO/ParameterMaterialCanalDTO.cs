using System.ComponentModel.DataAnnotations;

namespace ProgramSystem.Bll.Services.DTO;

public class ParameterMaterialCanalDTO
{
    public int ParameterId { get; set; }
    public Bll.Services.DTO.ParameterDTO? Parameter { get; set; } = null!;

    public int MaterialId { get; set; }
    public Bll.Services.DTO.MaterialDTO? Material { get; set; } = null!;

    public int CanalId { get; set; }
    public Bll.Services.DTO.CanalDTO? Canal { get; set; } = null!;

    [Required]
    public float Value { get; set; }
}