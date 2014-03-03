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

using NAudio.Wave;


namespace Sudoku
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public static class CustomCommands
    {
        public static readonly RoutedUICommand Exit = new RoutedUICommand
        ("Exit", "Exit", typeof(CustomCommands), new InputGestureCollection()
        {
            new KeyGesture(Key.F4, ModifierKeys.Alt)
        }
        );
    }

    public partial class MainWindow : Window
    {
        bool gameChanged = true;
        SudokuModel model;

        //Music
        WaveFileReader sound;
        WaveOut waveOut = new WaveOut();
        //End Music

        public MainWindow()
        {
            InitializeComponent();
            createCommandBindings();

            //Music
            sound = new WaveFileReader(Properties.Resources.asLongSong);
            LoopStream loop = new LoopStream(sound); // Loop class
            waveOut.Init(loop); //intializes the out device 
            waveOut.Play();
            //End Music



        }

        private void createCommandBindings()
        {
            CommandBinding bindNew = new CommandBinding();
            CommandBinding bindOpen = new CommandBinding();
            CommandBinding bindSave = new CommandBinding();
            CommandBinding bindExit = new CommandBinding();

            bindNew.Command = ApplicationCommands.New;
            bindNew.Executed += NewGame_Executed;
            bindNew.CanExecute += NewGame_CanExecute;
            CommandBindings.Add(bindNew);

            bindOpen.Command = ApplicationCommands.Open;
            bindOpen.Executed += OpenFile_Executed;
            bindOpen.CanExecute += OpenFile_CanExecute;
            CommandBindings.Add(bindOpen);

            bindSave.Command = ApplicationCommands.Save;
            bindSave.Executed += SaveFile_Executed;
            bindSave.CanExecute += SaveFile_CanExecute;
            CommandBindings.Add(bindSave);

            bindExit.Command = CustomCommands.Exit;
            bindExit.Executed += ExitGame_Executed;
            bindExit.CanExecute += ExitGame_CanExecute;
            CommandBindings.Add(bindExit);
        }

        public void NewGame_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        public void NewGame_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Inte implementerat ännu! Jobbar på det");
        }

        public void OpenFile_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        public void OpenFile_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            FileHandeling openSavedGame = new FileHandeling();
            model = this.menuComponent.GetSudokuModel;
            string[] savedFile = openSavedGame.OpenFile();
            //menuComponent.Visibility = Visibility.Collapsed;
            spelplanComponent.Visibility = Visibility.Visible;

            try
            {
                string[] savedGame = new string[81];
                for (int i = 0; i < 81; i++)
                {
                    savedGame[i] = savedFile[1].Substring(i, 1);
                }
                menuComponent.Visibility = Visibility.Collapsed;
                gridPrintComponent = model.PrintGrid(savedFile[2], gridPrintComponent, savedGame);
                gridPrintComponent.Visibility = Visibility.Visible;

                //försöker sätta fokus på första tomma cellen men funkar inte. 
                //Syftet är att slippa använda musen.
                int j = 0;
                while(!((TextBox)gridPrintComponent.nameGridPrint.Children[j]).IsEnabled){
                    j++;
                }
                TextBox temp = ((TextBox)gridPrintComponent.nameGridPrint.Children[j]);
                temp.Focus();

                spelplanComponent.timer.Text = savedFile[3];
                menuComponent.Timer();
                spelplanComponent.StartTimer2();
            }

            catch (Exception ex)
            {
                string error = ex.Data.ToString();
                if (model.GetSetNewGame)
                    spelplanComponent.Visibility = Visibility.Visible;
                else
                {
                    menuComponent.Visibility = Visibility.Visible;
                    spelplanComponent.Visibility = Visibility.Collapsed;
                }
            }
        }

        public void SaveFile_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (gameChanged)
                e.CanExecute = true;
        }

        public void SaveFile_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string[] game2Save = new string[4];
            model = this.menuComponent.GetSudokuModel;
            //Spara hårdkodad spelplan
            string[] strGameBoard = model.GetUseThisGrid;
            
            StringBuilder strbGameBoard = new StringBuilder();
            for (int i = 0; i < 81; i++)
                strbGameBoard.Append(strGameBoard[i]);
            game2Save[0] = strbGameBoard.ToString();

            //Spara användarens inmatade siffror            
            game2Save[1] = model.GetSetGame2Save;

            //Spara vilken spelplan/svårighetsgrad användaren valt
            game2Save[2] = model.GetDifficulty;

            //Spara tiden
            game2Save[3] = spelplanComponent.timer.Text;
            FileHandeling saveGame = new FileHandeling();
            saveGame.SaveFile(game2Save);
        }

        public void ExitGame_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        public void ExitGame_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void mnuHighscore_Click(object sender, RoutedEventArgs e)
        {
            highscoreComponent.Visibility = Visibility.Visible;
            menuComponent.Visibility = Visibility.Collapsed;
            gridPrintComponent.Visibility = Visibility.Collapsed;
            spelplanComponent.Visibility = Visibility.Collapsed;
        }
        private void Window_Closed_1(object sender, EventArgs e)
        {

            if (sound != null)
            {
                sound.Dispose();
                sound = null;
            }
            if (waveOut != null)
            {
                if (waveOut.PlaybackState == PlaybackState.Playing)
                    waveOut.Stop();
                waveOut.Dispose();
                waveOut = null;
            }

        }

       
        
        private void mnuRegler_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ett sudoku består av nio gånger nio rutor som i sin tur är indelade i nio större rutor. För att lösa ett sudoku skall man placera ut siffrorna 1-9 på spelfältet på ett sådant vis att varje siffra bara finns en gång per rad, en gång per kolumn och dessutom bara en gång per större ruta.",
                            "Hjälp");
        }

        private void mnuOmSudoku_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Detta Sudoku är utvecklat av:" + Environment.NewLine + "Ida Sabel" + Environment.NewLine + "Stefan Hall" + Environment.NewLine + "Hampus Wallin" + Environment.NewLine + "Nidaa Al-Botani",
                            "Om Sudoku");
        }

        private void mnuExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void mnuMusik1_Click(object sender, RoutedEventArgs e)
        {
            //checking if the sound is playing. Pause it if it is, play it if not
            // http://mark-dot-net.blogspot.co.uk/2014/02/fire-and-forget-audio-playback-with.html
            if (waveOut != null)
            {
                if (waveOut.PlaybackState == PlaybackState.Playing)
                {
                    waveOut.Pause();
                }
                else if (waveOut.PlaybackState == PlaybackState.Paused)
                {
                    waveOut.Play();
                }
            }
        }
        private void mnuTimer_Click(object sender, RoutedEventArgs e)
        {
            if(spelplanComponent.timerBox.Visibility == Visibility.Visible)
            spelplanComponent.timerBox.Visibility = Visibility.Collapsed;
            else if(spelplanComponent.timerBox.Visibility == Visibility.Collapsed)
                spelplanComponent.timerBox.Visibility = Visibility.Visible;
        }

        private void mnuAntaldrag_Click(object sender, RoutedEventArgs e)
        {
            if(spelplanComponent.antaldragbox.Visibility == Visibility.Visible)
                spelplanComponent.antaldragbox.Visibility = Visibility.Collapsed;
            else if(spelplanComponent.antaldragbox.Visibility == Visibility.Collapsed)
                spelplanComponent.antaldragbox.Visibility = Visibility.Visible;
        } 


    }
}
