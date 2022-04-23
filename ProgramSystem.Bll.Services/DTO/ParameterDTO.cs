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
        /// Единица измерения (описание, например "м/с")
        /// </summary>
        public string UnitOfMeasName { get; set; }
    }
}
