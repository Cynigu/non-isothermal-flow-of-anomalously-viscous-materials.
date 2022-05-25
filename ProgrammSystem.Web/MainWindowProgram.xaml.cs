using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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
            TextBox tb = sender as TextBox;
            if (tb.Text == "0" || (tb.Text=="" && e.Text=="0")) tb.Background = Brushes.Red;
            else tb.Background = Brushes.White;
        }
    }
}
