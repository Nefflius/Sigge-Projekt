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
        public MainWindow()
        {
            InitializeComponent();
            createCommandBindings();
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
            SudokuModel model = new SudokuModel();
            FileHandeling openSavedGame = new FileHandeling();
            string[] savedFile = openSavedGame.OpenFile();
            menuComponent.Visibility = Visibility.Collapsed;
            spelplanComponent.Visibility = Visibility.Visible;

            string[] savedGame = new string[81];
            for (int i = 0; i < 81; i++)
            {
                savedGame[i] = savedFile[1].Substring(i, 1);
            }

            gridPrintComponent = model.PrintGrid(savedFile[0], gridPrintComponent, savedGame);
            gridPrintComponent.Visibility = Visibility.Visible;
        }

        public void SaveFile_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (gameChanged)
                e.CanExecute = true;
        }

        public void SaveFile_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string[] game2Save = new string[3];

            //Spara hårdkodad spelplan
            string[] strGameBoard = this.menuComponent.GetSudokuModel.GetUseThisGrid;
            
            StringBuilder strbGameBoard = new StringBuilder();
            for (int i = 0; i < 81; i++)
                strbGameBoard.Append(strGameBoard[i]);
            game2Save[0] = strbGameBoard.ToString();

            //Spara användarens inmatade siffror
            StringBuilder strbGameBoard2Save = new StringBuilder();
            for (int i = 0; i < 81; i++)
            {
                this.menuComponent.GetSudokuModel.CellNumber = i;
                if (this.menuComponent.GetSudokuModel.GetSetGame2Save == null)
                    strbGameBoard2Save.Append(" ");
                else
                    strbGameBoard2Save.Append(this.menuComponent.GetSudokuModel.GetSetGame2Save);
            }
            game2Save[1] = strbGameBoard2Save.ToString();


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

    }
}
