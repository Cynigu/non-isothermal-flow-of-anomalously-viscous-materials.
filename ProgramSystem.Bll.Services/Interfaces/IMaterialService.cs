using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramSystem.Bll.Services.DTO;

namespace ProgramSystem.Bll.Services.Interfaces
{
    public interface IMaterialService
    {
        /// <summary>
        /// Получить все наименования материалов
        /// </summary>
        /// <returns>коллекция строк, в которых наименования материалов </returns>
        Task<ICollection<string>> GetAllNamesMaterialsAsync();

        /// <summary>
        /// Получить все объекты (с id и наименованиями) материалов
        /// </summary>
        /// <returns>Коллекцию материалов с id и наименованиями</returns>
        Task<ICollection<MaterialDTO>> GetAllMaterialsObjectsAsync();

        /// <summary>
        /// Добавляет материал по наименованию,
        /// Есть проверка на существование материала с таким же наименованием
        /// </summary>
        /// <param name="name"></param>
        Task AddMaterialByNameAsync(string name);

        /// <summary>
        /// Удаляет материал по id
        /// </summary>
        /// <param name="id"></param>
        Task RemoveMaterialByIdAsync(int id);
    }
}
