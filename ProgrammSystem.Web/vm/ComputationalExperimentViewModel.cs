using ProgrammSystem.Web.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammSystem.Web.vm
{
    public class ComputationalExperimentViewModel : ViewModelBase
    {
        private BaseCharacters _baseCharacters;
        public ComputationalExperimentViewModel(BaseCharacters baseCharacters)
        {
            _baseCharacters = baseCharacters;
        }
    }
}
