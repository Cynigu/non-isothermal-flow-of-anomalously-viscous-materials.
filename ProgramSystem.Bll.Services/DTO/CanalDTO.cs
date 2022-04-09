
namespace ProgramSystem.Bll.Services.DTO
{
    public class CanalDTO
    {
        /// <summary>
        /// ID не обязательно при создании нового объекта
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// Только чтобы из бд вытянуть эти данные
        /// </summary>
        public ICollection<ParameterMaterialCanalDTO>? ParameterMaterialCanal { get; set; }
    }
}
