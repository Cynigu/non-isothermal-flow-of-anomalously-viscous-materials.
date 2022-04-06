using System.ComponentModel;
using System.Runtime.CompilerServices;
using ProgrammSystem.Web.Annotations;

namespace ProgrammSystem.Web.vm
{
    public class ViewModelBase: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
