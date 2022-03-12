namespace ProgramSystem.Bll.Services.DTO
{
    public class MaterialDTO : IEntityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<ParameterMaterialCanalDTO>? ParameterMaterialCanal { get; set; }
    }
}
