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
        private string radioButtonChecked;

        /**********************************************************
        ANROP:      Anropas då Spela-knappen clickas.
        UPPGIFT:    Läser av radiobutton och skickar vidare vilken
                    nivå som användaren har valt.
                    Visar och döljer även spelplan och meny.
        ***********************************************************/
        private void spela_Click(object sender, RoutedEventArgs e)
        {
            var main = Application.Current.MainWindow as MainWindow;

          //  main.spelplanComponent.count = 0;
            main.spelplanComponent.lblAntalDrag.Content = "0";   
           
            main.menuComponent.Visibility = Visibility.Collapsed;
            main.spelplanComponent.Visibility = Visibility.Visible;
            //main.gridPrintComponent.Visibility = Visibility.Visible;

            SudokuModel model = new SudokuModel();

            if (Convert.ToBoolean(rbL.IsChecked))
                radioButtonChecked = "easy";
            else if (Convert.ToBoolean(rbM.IsChecked))
                radioButtonChecked = "medium";
            else if (Convert.ToBoolean(rbS.IsChecked))
                radioButtonChecked = "hard";

            main.gridPrintComponent = model.PrintGrid(radioButtonChecked, main.gridPrintComponent);

            main.gridPrintComponent.Visibility = Visibility.Visible;
                    
            main.spelplanComponent.start = true;   // Timer
            main.spelplanComponent.begins = DateTime.Now;  // Timer

        }
    }
}
