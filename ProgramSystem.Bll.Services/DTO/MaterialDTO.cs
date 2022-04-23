namespace ProgramSystem.Bll.Services.DTO
{
    public class MaterialDTO
    {
        /// <summary>
        /// ID не обязательно при создании нового объекта
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование материала
        /// </summary>
        public string Name { get; set; } = null!;

    }
}
