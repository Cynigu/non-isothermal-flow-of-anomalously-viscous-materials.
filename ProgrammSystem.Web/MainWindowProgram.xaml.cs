using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace ProgrammSystem.Web
{
    /// <summary>
    /// Логика взаимодействия для MainWindowProgram.xaml
    /// </summary>
    public partial class MainWindowProgram : Window
    {
        public MainWindowProgram()
        {
            InitializeComponent();
        }

        private void Text_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text.Last()) && !e.Text.Last().Equals('.');
        }
    }
}
