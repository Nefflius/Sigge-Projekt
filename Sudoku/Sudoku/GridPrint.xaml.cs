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
    /// Interaction logic for GridPrint.xaml
    /// </summary>
    public partial class GridPrint : UserControl
    {
        //SudokuModel sudokumodel = new SudokuModel();
        public GridPrint()
        {
            InitializeComponent();  
        }

        public GridPrint PrintGrid(string[] array)
        {
            Grid grid = this.nameGridPrint;

            for (int i = 0; i < 81; i++)
            {
                TextBox textbox = (TextBox) nameGridPrint.Children[i];
                string input = textbox.Text = array[i];
                
                if (input != " ") 
                {
                    textbox.IsEnabled = false;
                    textbox.Foreground = Brushes.Gray;
                    textbox.FontWeight = FontWeights.ExtraBold;
                } 
            }
            return this;
        }
    }
}
