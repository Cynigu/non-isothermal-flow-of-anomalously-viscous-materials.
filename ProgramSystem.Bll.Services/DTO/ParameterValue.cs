using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramSystem.Bll.Services.DTO
{
    public class ParameterValue
    {
        /// <summary>
        /// Наименование материала (или тип материала)
        /// </summary>
        public string MaterialName { get; set; }
        /// <summary>
        /// Наименование параметра
        /// </summary>
        public string ParameterName { get; set; }
        /// <summary>
        /// Тип параметра
        /// </summary>
        public string ParameterType { get; set; }
        /// <summary>
        /// Значение
        /// </summary>
        public float Value { get; set; }
        /// <summary>
        /// Наименование ед измерения
        /// </summary>
        public string UnitOfMeasName { get; set; }
    }
}
