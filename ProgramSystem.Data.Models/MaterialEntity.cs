using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramSystem.Data.Models
{
    public class MaterialEntity : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<ParameterMaterialCanalEntity>? ParameterMaterialCanal { get; set; }
    }
}
