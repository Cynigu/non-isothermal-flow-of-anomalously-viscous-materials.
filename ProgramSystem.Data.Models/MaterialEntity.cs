using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramSystem.Data.Models
{
    public class MaterialEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<VariableParameterMaterialCanalEntity>? VariableParameterMaterialCanal { get; set; }
        public ICollection<ParameterMaterialEntity>? ParameterMaterial { get; set; }
        public ICollection<EmpiricalParameterMaterialEntity>? EmpiricalParameterMaterial { get; set; }
    }
}