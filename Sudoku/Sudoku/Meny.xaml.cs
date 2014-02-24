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
        MainWindow main;
        SudokuModel model;
		public Meny()
		{
			InitializeComponent();
            model = new SudokuModel();
		}




		private static string radioButtonChecked;

        // Lägger till margin mellan radiobuttons och spelaknapp då Nytt Spel väljs.
        public void IsNowVisible()
        {
            rbGrid.Margin = new Thickness(70, 0, 70, 160);
        }

        public SudokuModel GetSudokuModel { get { return model; } }

		/**********************************************************
		ANROP:      Anropas då Spela-knappen clickas.
		UPPGIFT:    Läser av radiobutton och skickar vidare vilken
					nivå som användaren har valt.
					Visar och döljer även spelplan och meny.
		***********************************************************/
		private void spela_Click(object sender, RoutedEventArgs e)
		{
			main = Application.Current.MainWindow as MainWindow;
            model = new SudokuModel();
            model.GetSetNewGame = true;
			main.spelplanComponent.lblAntalDrag.Content = "0";

            main.spelplanComponent.Visibility = Visibility.Visible;
			main.menuComponent.Visibility = Visibility.Collapsed;
                gbL.Visibility = Visibility.Collapsed;
                gbM.Visibility = Visibility.Collapsed;
                gbS.Visibility = Visibility.Collapsed;
                rbL.IsChecked = false;
                rbM.IsChecked = false;
                rbS.IsChecked = false;
                rbGrid.Margin = new Thickness(70, 0, 70, 160);
                btnSpela.IsEnabled = false;
           

			main.gridPrintComponent = model.PrintGrid(radioButtonChecked, main.gridPrintComponent);
			main.gridPrintComponent.Visibility = Visibility.Visible;
					
			main.spelplanComponent.start = true;   // Timer
			main.spelplanComponent.begins = DateTime.Now;  // Timer
		}

		private void rb_Click(object sender, RoutedEventArgs e)
		{
            if (Convert.ToBoolean(rbL.IsChecked))
            {
                gbL.Visibility = Visibility.Visible;
                gbM.Visibility = Visibility.Collapsed;
                gbS.Visibility = Visibility.Collapsed;
                rbGrid.Margin = new Thickness(70, 0, 70, 0);

                if (Convert.ToBoolean(rbL_1.IsChecked))
                {
                    radioButtonChecked = "easy1";
                    btnSpela.IsEnabled = true;
                }
                else if (Convert.ToBoolean(rbL_2.IsChecked))
                {
                    radioButtonChecked = "easy2";
                    btnSpela.IsEnabled = true;
                }
                else if (Convert.ToBoolean(rbL_3.IsChecked))
                {
                    radioButtonChecked = "easy3";
                    btnSpela.IsEnabled = true;
                }
            }
            else if (Convert.ToBoolean(rbM.IsChecked))
            {
                gbM.Visibility = Visibility.Visible;
                gbL.Visibility = Visibility.Collapsed;
                gbS.Visibility = Visibility.Collapsed;
                rbGrid.Margin = new Thickness(70, 0, 70, 0);

                if (Convert.ToBoolean(rbM_1.IsChecked))
                {
                    radioButtonChecked = "medium1";
                    btnSpela.IsEnabled = true;
                }
                else if (Convert.ToBoolean(rbM_2.IsChecked))
                {
                    radioButtonChecked = "medium2";
                    btnSpela.IsEnabled = true;
                }
                else if (Convert.ToBoolean(rbM_3.IsChecked))
                {
                    radioButtonChecked = "medium3";
                    btnSpela.IsEnabled = true;
                }
            }
            else if (Convert.ToBoolean(rbS.IsChecked))
            {
                gbS.Visibility = Visibility.Visible;
                gbL.Visibility = Visibility.Collapsed;
                gbM.Visibility = Visibility.Collapsed;
                rbGrid.Margin = new Thickness(70, 0, 70, 0);

                if (Convert.ToBoolean(rbS_1.IsChecked))
                {
                    radioButtonChecked = "hard1";
                    btnSpela.IsEnabled = true;
                }
                else if (Convert.ToBoolean(rbS_2.IsChecked))
                {
                    radioButtonChecked = "hard2";
                    btnSpela.IsEnabled = true;
                }
                else if (Convert.ToBoolean(rbS_3.IsChecked))
                {
                    radioButtonChecked = "hard3";
                    btnSpela.IsEnabled = true;
                }
            }
		}
	}
}
