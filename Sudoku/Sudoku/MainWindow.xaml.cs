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
        }

        private void clickAvsluta(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void clickRätta(object sender, RoutedEventArgs e)
        {

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

        public void openGame()
        {
            FileHandeling openSudokoFile = new FileHandeling("");
            SavedGame ContinueOldGame = new SavedGame();
            ContinueOldGame.Height = 300;
            ContinueOldGame.Width = 300;

            this.Content = (ContinueOldGame.UpdateGame(openSudokoFile.OpenFile()));
        }

        private void mnuOpen_Click_1(object sender, RoutedEventArgs e)
        {
            openGame();
        }

    }
}
