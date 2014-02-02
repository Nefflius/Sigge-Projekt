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
    /// Interaction logic for SavedGame.xaml
    /// </summary>
    public partial class SavedGame : UserControl
    {
        public SavedGame()
        {
            InitializeComponent();
        }

        public UserControl UpdateGame(string sudokoGame)
        {
            Grid grid = this.grdSavedGame;
            for (int i = 0; i < sudokoGame.Length; ++i)
            {
                TextBox _sudokoCell = (TextBox)grid.Children[i];
                _sudokoCell.Text = sudokoGame.Substring(i, 1);
            }
            return this;
        }
    }
}
