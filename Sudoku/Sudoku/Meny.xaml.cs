using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sudoku
{
    /// <summary>
    /// Interaction logic for Meny.xaml
    /// </summary>
    public partial class Meny : UserControl
    {
        public Meny()
        {
            InitializeComponent();
        }

        private void spela_Click(object sender, RoutedEventArgs e)
        {
            var main = Application.Current.MainWindow as MainWindow;

            if (Convert.ToBoolean(rbL.IsChecked))
            {
                main.easyComponent1.Visibility = Visibility.Visible;
            }
            if (Convert.ToBoolean(rbM.IsChecked))
            {
                main.mediumComponent1.Visibility = Visibility.Visible;
            }
            if (Convert.ToBoolean(rbS.IsChecked))
            {
                main.hardComponent1.Visibility = Visibility.Visible;
            }

            main.menuComponent.Visibility = Visibility.Collapsed;
            main.spelplanComponent.Visibility = Visibility.Visible;
        }
    }
}
