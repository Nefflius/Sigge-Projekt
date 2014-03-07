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
using System.Windows.Media.Animation; // Animationer

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
            System.Windows.Forms.DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Din spelomgång kommer att avbrytas, Är du säker på att du vill avsluta Sudoku?", "Spelomgång avbruten", System.Windows.Forms.MessageBoxButtons.YesNo);
            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Current.Shutdown();                 //Stänger av programet
            }
            else { }
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
                //fokus i spelplan
                int j = 0;
                while (!((TextBox)main.gridPrintComponent.nameGridPrint.Children[j]).IsEnabled)
                {
                    j++;
                }
                TextBox temp = ((TextBox)main.gridPrintComponent.nameGridPrint.Children[j]);
                temp.Focus();
            }
    
        }

        private void clickNyttSpel(object sender, RoutedEventArgs e)        //Nytt spel
        {
            var main = Application.Current.MainWindow as MainWindow;
            SudokuModel model = main.menuComponent.GetSudokuModel;
            main.Enable_DisablePrint(false);
            main.Enable_DisableSave(false);
            System.Windows.Forms.DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Din spelomgång kommer att avbrytas, Är du säker på att du vill starta ett nytt spel?", "Spelomgång avbruten", System.Windows.Forms.MessageBoxButtons.YesNo);
            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                main.menuComponent.Visibility = Visibility.Visible;
                main.spelplanComponent.Visibility = Visibility.Collapsed;
                main.gridPrintComponent.Visibility = Visibility.Collapsed;
                main.mnuInställningar.Visibility = Visibility.Collapsed;
                model.GetSetNewGame = false;

                btnStart.Visibility = Visibility.Hidden;
                btnPause.Visibility = Visibility.Visible;
                main.pauseComponent.Visibility = Visibility.Hidden;

                main.menuComponent.IsNowVisible();

                System.Windows.Media.Animation.DoubleAnimation da = new System.Windows.Media.Animation.DoubleAnimation();
                da.From = -950;
                da.To = 0;
                da.Duration = new Duration(TimeSpan.FromMilliseconds(1));
                TranslateTransform rt = new TranslateTransform();
                main.gridPrintComponent.RenderTransform = rt;
                rt.BeginAnimation(TranslateTransform.YProperty, da);
            }
            else { }
        }

        public void GameWon(string nameinput, string time)
        {
            var main = Application.Current.MainWindow as MainWindow;
            SudokuModel model = new SudokuModel();
            string moves = lblAntalDrag.Content.ToString();
            string solution = model.getThisSolution();
            main.highscoreComponent.addHighscore(nameinput, solution, time, moves);
            main.highscoreComponent.Rubrik.Visibility = Visibility.Visible;
        }

        //När "Fusk" klickas hämtas lösning i SudokuModel
        private void clickFusk(object sender, RoutedEventArgs e)
        {
            var main = Application.Current.MainWindow as MainWindow;
            SudokuModel model = new SudokuModel();
            model.fuska(main.gridPrintComponent);
        }
        
        // *****  Pause button click (Timer) ********
        public void btnPause_Click(object sender, RoutedEventArgs e)
        {
            var main = Application.Current.MainWindow as MainWindow;
            
            main.menuComponent.start = false;
            btnPause.Visibility = Visibility.Hidden;
            btnStart.Visibility = Visibility.Visible;
            main.Enable_DisablePrint(false);
            main.Enable_DisableSave(false);
            main.pauseComponent.Visibility = Visibility.Visible;
            btnRätta.IsEnabled = false;

            System.Windows.Media.Animation.DoubleAnimation da = new System.Windows.Media.Animation.DoubleAnimation();
            da.From = 0;
            da.To = 950;
            da.Duration = new Duration(TimeSpan.FromMilliseconds(1000));
            TranslateTransform rt = new TranslateTransform();
            main.gridPrintComponent.RenderTransform = rt;
            rt.BeginAnimation(TranslateTransform.YProperty, da);

            System.Windows.Media.Animation.DoubleAnimation du = new System.Windows.Media.Animation.DoubleAnimation();
            du.From = -950;
            du.To = 0;
            du.Duration = new Duration(TimeSpan.FromMilliseconds(1000));
            TranslateTransform tt = new TranslateTransform();
            main.pauseComponent.RenderTransform = tt;
            tt.BeginAnimation(TranslateTransform.YProperty, du);
        }

        public void StartTimer()
        {
            var main = Application.Current.MainWindow as MainWindow;
            TimeSpan timerBox;
            if (TimeSpan.TryParse(timer.Text.Replace("m", "").Replace("h", ""), out timerBox))
                
            main.menuComponent.begins = (DateTime.Now - timerBox);
            main.menuComponent.start = true;
            btnPause.Visibility = Visibility.Visible;
            btnStart.Visibility = Visibility.Hidden;
            main.Enable_DisablePrint(true);
            main.Enable_DisableSave(true);

            bool ok = true;
            for (int i = 0; i < 81; i++)
            {
                TextBox tb = (TextBox) main.gridPrintComponent.nameGridPrint.Children[i];
                if (tb.Text != "")
                    ok = ok && true;
                else
                    ok = ok && false;
            }
            if (ok)
                btnRätta.IsEnabled = true;
            else
                btnRätta.IsEnabled = false;

            int j = 0;
            while (!((TextBox)main.gridPrintComponent.nameGridPrint.Children[j]).IsEnabled && j < 81)
            {
                j++;
                if (j == 80)
                    break;
            }
            if (j < 81)
            {
                TextBox temp = ((TextBox)main.gridPrintComponent.nameGridPrint.Children[j]);
                temp.Focus();
            }
            else
            { }

            System.Windows.Media.Animation.DoubleAnimation da = new System.Windows.Media.Animation.DoubleAnimation();
            da.From = -950;
            da.To = 0;
            da.Duration = new Duration(TimeSpan.FromMilliseconds(1000));
            TranslateTransform rt = new TranslateTransform();
            main.gridPrintComponent.RenderTransform = rt;
            rt.BeginAnimation(TranslateTransform.YProperty, da);

            System.Windows.Media.Animation.DoubleAnimation du = new System.Windows.Media.Animation.DoubleAnimation();
            du.From = 0;
            du.To = 950;
            du.Duration = new Duration(TimeSpan.FromMilliseconds(1000));
            TranslateTransform tt = new TranslateTransform();
            main.pauseComponent.RenderTransform = tt;
            tt.BeginAnimation(TranslateTransform.YProperty, du);
        }

        public void StartTimer2()
        {
            var main = Application.Current.MainWindow as MainWindow;
            TimeSpan timerBox;
            if (TimeSpan.TryParse(timer.Text.Replace("m", "").Replace("h", ""), out timerBox))
            {
                main.menuComponent.begins = (DateTime.Now - timerBox);
                main.menuComponent.start = true;
            }

            bool ok = true;
            for (int i = 0; i < 81; i++)
            {
                TextBox tb = (TextBox)main.gridPrintComponent.nameGridPrint.Children[i];
                if (tb.Text != "")
                    ok = ok && true;
                else
                    ok = ok && false;
            }
            if (ok)
                btnRätta.IsEnabled = true;
            else
                btnRätta.IsEnabled = false;
        }

        // *******  start button click (Timer)   *********
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            StartTimer();
        }

        private void btnMusicOn_Click(object sender, RoutedEventArgs e)
        {
            var main = Application.Current.MainWindow as MainWindow;

            main.mnuMusik.IsChecked = false;
            btnMusicOn.Visibility = Visibility.Hidden;
            btnMusicOff.Visibility = Visibility.Visible;

            main.wplayer.URL = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Musik.mp3";
            main.wplayer.controls.stop();
        }

        private void btnMusicOff_Click(object sender, RoutedEventArgs e)
        {
            var main = Application.Current.MainWindow as MainWindow;

            if (!main.MusicCheck)
            {
                btnPause_Click(sender, e);
                main.pauseComponent.Visibility = Visibility.Hidden;

                MusicWindow mwin = new MusicWindow();
                mwin.Show();
                main.IsEnabled = false;
            }
            else
            {
                try
                {
                    main.wplayer.URL = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Musik.mp3";
                    main.wplayer.controls.play();

                    main.mnuMusik.IsChecked = true;
                    btnMusicOn.Visibility = Visibility.Visible;
                    btnMusicOff.Visibility = Visibility.Hidden;
                }
                catch
                {
                    btnPause_Click(sender, e);
                    main.pauseComponent.Visibility = Visibility.Hidden;

                    MusicWindow mwin = new MusicWindow();
                    mwin.Show();
                    main.IsEnabled = false;
                }
            }
        }
    }
}
