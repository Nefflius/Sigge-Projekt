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


using System.Windows.Threading; // timer

namespace Sudoku
{
    /// <summary>
    /// Interaction logic for Spelplan.xaml
    /// </summary>
    public partial class Spelplan : UserControl
    {   
        public DateTime begins;
        DispatcherTimer timerChanged;
        public bool start = false; 

        public Spelplan()
        {
            InitializeComponent();
            timerChanged = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                if (start)
                {
                    timer.Text = new DateTime((DateTime.Now - begins).Ticks).ToString("HH:mm:ss");
                }
            }, this.Dispatcher);
        }

        private void clickAvsluta(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();                 //Stänger av programet
        }

        private void clickRätta(object sender, RoutedEventArgs e)
        {
            var main = Application.Current.MainWindow as MainWindow;            
            Button btn = (Button) sender;

            if (btn.Content.ToString() == "RÄTTA")
            {
                btn.Content = "FORTSÄTT";
                main.gridPrintComponent.Rätta(main.gridPrintComponent);
            }
            else if (btn.Content.ToString() == "FORTSÄTT")
            {
                btn.Content = "RÄTTA";
                main.gridPrintComponent.continueGame();
            }

            bool var = SudokuModel.send;
            if (var == true)
                MessageBox.Show("Du har vunnit, Grattis!");
        }

        private void clickNyttSpel(object sender, RoutedEventArgs e)
        {
            var main = Application.Current.MainWindow as MainWindow;
           
            main.menuComponent.Visibility = Visibility.Visible;
            main.spelplanComponent.Visibility = Visibility.Collapsed;
            main.gridPrintComponent.Visibility = Visibility.Collapsed;

            btnRätta.Content = "RÄTTA";
        }

        private void clickHjälp(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ett sudoku består av nio gånger nio rutor som i sin tur är indelade i nio större rutor. För att lösa ett sudoku skall man placera ut siffrorna 1-9 på spelfältet på ett sådant vis att varje siffra bara finns en gång per rad, en gång per kolumn och dessutom bara en gång per större ruta.",
                             "Hjälp");
        }
    }
}
