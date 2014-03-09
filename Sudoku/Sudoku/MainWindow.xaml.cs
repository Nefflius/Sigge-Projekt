using System;
using System.Collections.Generic;
using System.IO;
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
using WMPLib;



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
        bool printEnabled = false;
        bool saveEnabled = false;
        public bool MusicCheck = false;
        SudokuModel model;

        public MainWindow()
        {
            InitializeComponent();
            createCommandBindings();
            startmusik();
        }
        public WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
        public void startmusik()
        {
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Musik.mp3"))
            {
                wplayer.URL = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Musik.mp3";
                wplayer.settings.setMode("loop", true);
                wplayer.controls.play();

                spelplanComponent.btnMusicOn.Visibility = Visibility.Visible;
                spelplanComponent.btnMusicOff.Visibility = Visibility.Hidden;
                MusicCheck = true;
                mnuMusik.IsChecked = true;
            }
            else
            {
                MusicCheck = false;
                mnuMusik.IsChecked = false;
            }
        }
        private void createCommandBindings()
        {
            CommandBinding bindNew = new CommandBinding();
            CommandBinding bindOpen = new CommandBinding();
            CommandBinding bindSave = new CommandBinding();
            CommandBinding bindPrint = new CommandBinding();
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

            bindPrint.Command = ApplicationCommands.Print;
            bindPrint.Executed += Print_Executed;
            bindPrint.CanExecute += Print_CanExecute;
            CommandBindings.Add(bindPrint);

            bindExit.Command = CustomCommands.Exit;
            bindExit.Executed += ExitGame_Executed;
            bindExit.CanExecute += ExitGame_CanExecute;
            CommandBindings.Add(bindExit);
        }

        public void Enable_DisablePrint(bool enableOrDisablePrint)
        {
            printEnabled = enableOrDisablePrint;
        }

        public void Enable_DisableSave(bool enableOrDisableSave)
        {
            saveEnabled = enableOrDisableSave;
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
                gridPrintComponent.ShowAndResetSpelplan();

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

                printEnabled = true;
                saveEnabled = true;

                menuComponent.rbL.IsChecked = false;
                menuComponent.rbM.IsChecked = false;
                menuComponent.rbS.IsChecked = false;
                menuComponent.gbL.Visibility = Visibility.Collapsed;
                menuComponent.gbM.Visibility = Visibility.Collapsed;
                menuComponent.gbS.Visibility = Visibility.Collapsed;
                mnuInställningar.Visibility = Visibility.Visible;
            }

            catch (Exception ex)
            {
                string error = ex.Data.ToString();
                if (model.GetSetNewGame)
                    spelplanComponent.Visibility = Visibility.Visible;
                else if (menuComponent.Visibility == Visibility.Visible)
                    spelplanComponent.Visibility = Visibility.Collapsed;
                else if (highscoreComponent.Visibility == Visibility.Visible)
                    spelplanComponent.Visibility = Visibility.Collapsed;
            }
        }

        public void SaveFile_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (gameChanged && saveEnabled)
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

        public void Print_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (printEnabled)
                e.CanExecute = true;
        }

        public void Print_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            GridPrint printSudoku = new GridPrint();
            printSudoku.Width = 700;
            printSudoku.Height = 520;
            //var margin = printSudoku.gridBorder.Margin;
            //margin.Left = 0;
            printSudoku.gridBorder.Margin = new Thickness(0);
            model = this.menuComponent.GetSudokuModel;
            string strGame2Print = model.GetSetGame2Save;
            string nrOfMoves = spelplanComponent.lblAntalDrag.Content.ToString();
            for (int i = 0; i < 81; i++)
            {
                TextBox tb = (TextBox)printSudoku.nameGridPrint.Children[i];
                tb.Text = strGame2Print.Substring(i, 1);
            }
            string[] usingGrid = model.GetUseThisGrid;
            for (int i = 0; i < 81; i++)
            {
                TextBox tb = (TextBox)printSudoku.nameGridPrint.Children[i];
                if (tb.Text == usingGrid[i])
                {
                    tb.FontWeight = FontWeights.Bold;
                    tb.Foreground = Brushes.Gray;
                }
            }
            spelplanComponent.lblAntalDrag.Content = nrOfMoves;
            PrintDialog dialogPrint = new PrintDialog();
            if (dialogPrint.ShowDialog() != true)
                return;
            printSudoku.Measure(new Size(dialogPrint.PrintableAreaWidth, dialogPrint.PrintableAreaHeight));
            printSudoku.Arrange(new Rect(new Point(50, 50), gridPrintComponent.DesiredSize));
            dialogPrint.PrintVisual(printSudoku, "Sudoku-utskrift");
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
            model = this.menuComponent.GetSudokuModel;
            if (gridPrintComponent.Visibility != Visibility.Collapsed)
            {
                System.Windows.Forms.DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Spelet kommer att avbrytas, Är du säker på att du vill till Highscore?", "Avbrutet spel", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Exclamation);
                if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                {
                    highscoreComponent.Visibility = Visibility.Visible;
                    menuComponent.Visibility = Visibility.Collapsed;
                    gridPrintComponent.Visibility = Visibility.Collapsed;
                    spelplanComponent.Visibility = Visibility.Collapsed;
                    mnuInställningar.Visibility = Visibility.Collapsed;
                    gridPrintComponent.HideAndResetSpelplan();
                    model.GetSetNewGame = false;
                }
                if (dialogResult == System.Windows.Forms.DialogResult.No) { }
            }
            else
            {
                highscoreComponent.Visibility = Visibility.Visible;
                menuComponent.Visibility = Visibility.Collapsed;
                gridPrintComponent.Visibility = Visibility.Collapsed;
                spelplanComponent.Visibility = Visibility.Collapsed;
                model.GetSetNewGame = false;
            }

        }

        private void mnuRegler_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ett sudoku består av nio gånger nio rutor som i sin tur är indelade i nio större rutor. För att lösa ett sudoku skall man placera ut siffrorna 1-9 på spelfältet på ett sådant vis att varje siffra bara finns en gång per rad, en gång per kolumn och dessutom bara en gång per större ruta.","Hjälp");
        }

        private void mnuOmSudoku_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Detta Sudoku är utvecklat av:" + Environment.NewLine + "Ida Sabel" + Environment.NewLine + "Stefan Hall" + Environment.NewLine + "Hampus Wallin" + Environment.NewLine + "Nidaa Al-Botani", "Om Sudoku",MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void mnuExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
       

        private void mnuMusik_Click(object sender, RoutedEventArgs e)
        {
            var main = Application.Current.MainWindow as MainWindow;

            if (MusicCheck)
            {
                wplayer.URL = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Musik.mp3";
                wplayer.controls.stop();
                MusicCheck = false;

                main.spelplanComponent.btnMusicOff.Visibility = Visibility.Visible;
                main.spelplanComponent.btnMusicOn.Visibility = Visibility.Hidden;
            }
            else
            {
                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Musik.mp3"))
                {
                    wplayer.URL = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Musik.mp3";
                    wplayer.settings.setMode("loop", true);
                    wplayer.controls.play();
                    MusicCheck = true;
                    main.spelplanComponent.btnMusicOff.Visibility = Visibility.Hidden;
                    main.spelplanComponent.btnMusicOn.Visibility = Visibility.Visible;
                }
                else
                {
                    main.spelplanComponent.btnPause_Click(sender, e);

                    MusicWindow mwin = new MusicWindow();
                    mwin.Show();
                }                
            }
        }

        private void mnuTimer_Click(object sender, RoutedEventArgs e)
        {
            if (spelplanComponent.timerBox.Visibility == Visibility.Visible)
                spelplanComponent.timerBox.Visibility = Visibility.Collapsed;

            else if (spelplanComponent.timerBox.Visibility == Visibility.Collapsed)
                spelplanComponent.timerBox.Visibility = Visibility.Visible;
        }

        private void mnuAntaldrag_Click(object sender, RoutedEventArgs e)
        {
            if (spelplanComponent.antaldragbox.Visibility == Visibility.Visible)
                spelplanComponent.antaldragbox.Visibility = Visibility.Collapsed;

            else if (spelplanComponent.antaldragbox.Visibility == Visibility.Collapsed)
                spelplanComponent.antaldragbox.Visibility = Visibility.Visible;
        } 
    }
}
