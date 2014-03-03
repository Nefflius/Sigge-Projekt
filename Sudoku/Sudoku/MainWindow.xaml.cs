﻿using System;
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
        SudokuModel model;
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
                spelplanComponent.StartTimer();
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

        public void Print_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        public void Print_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            GridPrint printSudoko = new GridPrint();
            printSudoko.Width = 700;
            printSudoko.Height = 520;
            var margin = printSudoko.gridBorder.Margin;
            margin.Left = 0;
            printSudoko.gridBorder.Margin = margin;
            model = this.menuComponent.GetSudokuModel;
            string strGame2Print = model.GetSetGame2Save;
            for (int i = 0; i < 81; i++)
            {
                TextBox tb = (TextBox)printSudoko.nameGridPrint.Children[i];
                tb.Text = strGame2Print.Substring(i);
            }
            PrintDialog dialogPrint = new PrintDialog();
            if (dialogPrint.ShowDialog() != true)
                return;
            printSudoko.Measure(new Size(dialogPrint.PrintableAreaWidth, dialogPrint.PrintableAreaHeight));
            printSudoko.Arrange(new Rect(new Point(50, 50), gridPrintComponent.DesiredSize));
            dialogPrint.PrintVisual(printSudoko, "Sudokoutskrift");
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
