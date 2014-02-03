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
    /// Interaction logic for Spelplan.xaml
    /// </summary>
    public partial class Spelplan : UserControl
    {
        public Spelplan()
        {
            InitializeComponent();
        }

        private void clickAvsluta(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void clickRätta(object sender, RoutedEventArgs e)
        {
            // Kontrollera så att spelplan är HELT ifylld.
        }

        private void clickNyttSpel(object sender, RoutedEventArgs e)
        {
            var main = Application.Current.MainWindow as MainWindow;
            main.menuComponent.Visibility = Visibility.Visible;
            main.spelplanComponent.Visibility = Visibility.Collapsed;
            main.gridPrintComponent.Visibility = Visibility.Collapsed;
        }

        private void clickHjälp(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ett sudoku består av nio gånger nio rutor som i sin tur är indelade i nio större rutor. För att lösa ett sudoku skall man placera ut siffrorna 1-9 på spelfältet på ett sådant vis att varje siffra bara finns en gång per rad, en gång per kolumn och dessutom bara en gång per större ruta.",
                             "Hjälp");  
        }
        
    }
}
