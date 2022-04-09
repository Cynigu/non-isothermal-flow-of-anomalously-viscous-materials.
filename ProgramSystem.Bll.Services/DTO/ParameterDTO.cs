namespace ProgramSystem.Bll.Services.DTO
{
    public class ParameterDTO
    {
        /// <summary>
        /// Id - не обязательно при содании нового объекта
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Тип параметра
        /// </summary>
        public string TypeParameter { get; set; } = null!; // тип параметра
        /// <summary>
        /// Название параметра
        /// </summary>
        public string Name { get; set; } = null!;// название параметра
        /// <summary>
        /// Id ед.измерения
        /// </summary>
        public int UnitOfMeasId { get; set; }
        public UnitOfMeasDTO UnitOfMeasEntity { get; set; } = null!; // единица измерения
        public ICollection<ParameterMaterialCanalDTO>? ParameterMaterialCanal { get; set; }
    }
}
