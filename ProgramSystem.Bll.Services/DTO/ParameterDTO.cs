namespace ProgramSystem.Bll.Services.DTO
{
    public class ParameterDTO: IEntityDTO
    {
        public int Id { get; set; }
        public string TypeParameter { get; set; } = null!; // тип параметра
        public string Name { get; set; } // название параметра
        public int UnitOfMeasId { get; set; }
        public UnitOfMeasDTO UnitOfMeasEntity { get; set; } = null!; // единица измерения
        public ICollection<ParameterMaterialCanalDTO>? ParameterMaterialCanal { get; set; }
    }
}
