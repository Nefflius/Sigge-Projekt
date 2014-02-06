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
    /// Interaction logic for GridPrint.xaml
    /// </summary>
    public partial class GridPrint : UserControl
    {
        //SudokuModel sudokumodel = new SudokuModel();
        public GridPrint()
        {
            InitializeComponent();  
        }
        GridPrint gameBoard;
        

        /*****************************************************
        ANROP:      PrintGrid(string[]);
        UPPGIFT:    Tar emot array med spelplan-siffror, 
                    skriver ut spelplan i GridPrint-usercontrol.
        ******************************************************/

        public GridPrint PrintGrid(string[] array)
        {
            //Grid grid = this.nameGridPrint;

            for (int i = 0; i < 81; i++)
            {
                TextBox textbox = (TextBox) nameGridPrint.Children[i];
                
                string input = array[i];

                if (input != " ") 
                {
                    textbox.Text = array[i];

                    textbox.IsEnabled = false;
                    textbox.Foreground = Brushes.Gray;
                    textbox.BorderBrush = Brushes.Gray;
                    textbox.FontWeight = FontWeights.ExtraBold;
                } 
            }

            var main = Application.Current.MainWindow as MainWindow;
            main.PrintGrid(this);

            gameBoard = this;
            
            return this;
        }

        /****************************************************************
        ANROP:      Rätta();
        UPPGIFT:    Kontrollerar om alla textbox är ifyllda, skickar dem
                    isåfall till Rättafunktion i Sudokumodel.
        *****************************************************************/
        public void Rätta() 
        {
            string[] arr = new string[81];
            for (int i = 0; i < 81; i++)  // Läs av alla rutor, om alla är ifyllda, rätta!
            {
                TextBox tb = (TextBox)nameGridPrint.Children[i];

                arr[i] = tb.Text;
                if (arr[i] == "")
                {
                    MainWindow main = Application.Current.MainWindow as MainWindow;
                    main.ShowTextBox();
                    return;
                }
            }

            SudokuModel model = new SudokuModel();
            model.Rätta(arr);               // skicka till Rätta-funktion i Sudokumodel                      
        }
        
        /*****************************************************************
        ANROP:      MarkeraSiffror(bool[]);
        UPPGIFT:    Markerar rätta siffror med grönt och felaktiga med rött.
        ******************************************************************/
        public void MarkeraSiffror(bool[] array)
        {
            int length = array.Length;
            for (int i = 0; i < length; i++)
            {
                TextBox tb = (TextBox)nameGridPrint.Children[i];

                if (array[i])
                    tb.BorderBrush = Brushes.Green;
                else
                    tb.BorderBrush = Brushes.Red;
            }
        }
    }
}
