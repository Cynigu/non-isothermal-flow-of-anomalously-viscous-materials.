namespace ProgramSystem.Bll.Services.DTO
{
    public class MaterialDTO
    {
        /// <summary>
        /// ID не обязательно при создании нового объекта
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование канала
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Только чтобы из бд вытянуть эти данные
        /// </summary>
        public ICollection<ParameterMaterialCanalDTO>? ParameterMaterialCanal { get; set; }

    }
}
