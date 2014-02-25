using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; //
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
        //public DateTime begins;
        //DispatcherTimer timerChanged;
        //public bool start = false;
        
        public Spelplan()
        {
            InitializeComponent();
            //timerChanged = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            //{
            //    if (start)
            //    {
            //        timer.Text = new DateTime((DateTime.Now - begins).Ticks).ToString("HH:mm:ss");
            //    }
            //}, this.Dispatcher);
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
    
        }

        private void clickNyttSpel(object sender, RoutedEventArgs e)        //Nytt spel
        {
            var main = Application.Current.MainWindow as MainWindow;
           
            main.menuComponent.Visibility = Visibility.Visible;
            main.spelplanComponent.Visibility = Visibility.Collapsed;
            main.gridPrintComponent.Visibility = Visibility.Collapsed;

            btnStart.Visibility = Visibility.Hidden;    //
            btnPause.Visibility = Visibility.Visible;    //

            main.menuComponent.IsNowVisible();

            btnRätta.Content = "RÄTTA";
        }

        public void GameWon(string nameinput, string time)
        {
            var main = Application.Current.MainWindow as MainWindow;
            SudokuModel model = new SudokuModel();
            
            string moves = lblAntalDrag.Content.ToString();

            // if winnersList.rows =< 10
            // else 
            // if tiden är bättre än nr 10 i winnersList
            string solution = model.getThisSolution();

            main.highscoreComponent.addHighscore(nameinput, solution, time, moves);
        }

        //När "Fusk" klickas hämtas lösning i SudokuModel
        private void clickFusk(object sender, RoutedEventArgs e)
        {
            var main = Application.Current.MainWindow as MainWindow;
            SudokuModel model = new SudokuModel();
            model.fuska(main.gridPrintComponent);
        }
        
        // *****  Pause button click (Timer) ********
        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            var main = Application.Current.MainWindow as MainWindow;

            main.menuComponent.start = false;
            btnPause.Visibility = Visibility.Hidden;
            btnStart.Visibility = Visibility.Visible;
        }


        // *******  start button click (Timer)   *********
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            var main = Application.Current.MainWindow as MainWindow;
            TimeSpan timerBox;
            if (TimeSpan.TryParse(timer.Text.Replace("m", "").Replace("h", ""), out timerBox))

                main.menuComponent.begins = (DateTime.Now - timerBox);
            main.menuComponent.start = true;
            btnPause.Visibility = Visibility.Visible;
            btnStart.Visibility = Visibility.Hidden;

        }


    }
}
