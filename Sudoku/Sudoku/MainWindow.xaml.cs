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
                (
                        "Exit",
                        "Exit",
                        typeof(CustomCommands),
                        new InputGestureCollection()
                                {
                                        new KeyGesture(Key.F4, ModifierKeys.Alt)
                                }
                );

        //Define more commands here, just like the one above
    }

    public partial class MainWindow : Window
    {
        bool gameChanged = true;
        public MainWindow()
        {
            InitializeComponent();
            createCommandBindings();
        }

        //private void ExitCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    e.CanExecute = true;
        //}

        //private void ExitCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        //{
        //    Application.Current.Shutdown();
        //}

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

        public void PrintGrid(GridPrint newGameBoard)
        {
            newGameBoard.SetValue(Grid.ColumnSpanProperty, 3);

            grdMain.Children.Add(newGameBoard);
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
            FileHandeling openSavedGame = new FileHandeling("");
            string savedGame = openSavedGame.OpenFile();
            model.PrintGrid(savedGame);
        }

        public void SaveFile_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (gameChanged)
                e.CanExecute = true;
        }

        public void SaveFile_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("inte implementerat ännu. Jobbar på det :) ");
        }

        public void ExitGame_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;    
        }

        public void ExitGame_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public void ShowTextBox()
        {
            // Textruta dyker upp mitt i som säger att användare måste
            // fylla i alla rutor innan den rättar
            // sedan: Click Enter to continue...
        }
    }
}
