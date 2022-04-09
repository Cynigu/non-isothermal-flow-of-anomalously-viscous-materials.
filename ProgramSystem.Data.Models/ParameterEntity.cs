using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramSystem.Data.Models
{
    public class ParameterEntity
    {
        public int Id { get; set; }
        public string TypeParameter { get; set; } = null!; // тип параметра
        public string Name { get; set; } // название параметра
        public int UnitOfMeasId { get; set; }
        public UnitOfMeasEntity UnitOfMeas { get; set; } = null!; // единица измерения
        public ICollection<ParameterMaterialCanalEntity>? ParameterMaterialCanal { get; set; }
    }
}
