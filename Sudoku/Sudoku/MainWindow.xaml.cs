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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CommandBinding bindOpen = new CommandBinding();
            bindOpen.Command = ApplicationCommands.Open;
            bindOpen.Executed += OpenFile_Executed;
            bindOpen.CanExecute += OpenFile_CanExecute;
            CommandBindings.Add(bindOpen);
        }

        private void clickAvsluta(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public void PrintGrid(GridPrint newGameBoard)
        {
            newGameBoard.SetValue(Grid.ColumnSpanProperty, 3);

            grdMain.Children.Add(newGameBoard);
        }

        private void clickNyttSpel(object sender, RoutedEventArgs e)
        {

        }

        private void mnuExit_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void mnuSave_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void mnuOpen_Click_1(object sender, RoutedEventArgs e)
        {

        }

        public void OpenFile_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        public void OpenFile_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            FileHandeling openSavedGame = new FileHandeling("");
            openSavedGame.OpenFile();
        }
    }
}
