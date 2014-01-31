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
    /// Interaction logic for Hard1.xaml
    /// </summary>
    public partial class Hard1 : UserControl
    {
        int[] _solutionHard1 = new int[81] {7,9,6,
                                            5,4,2,
                                            8,3,1,

                                            1,4,5,
                                            9,3,8,
                                            6,7,2,
                                            
                                            3,8,2,
                                            6,7,1,
                                            9,4,5,

                                            4,6,7,
                                            3,2,5,
                                            9,1,8,

                                            2,9,3,
                                            7,8,1,
                                            5,6,4,
                                            
                                            5,1,8,
                                            4,9,6,
                                            7,2,3,
                                            
                                            2,8,3,
                                            1,7,9,
                                            6,5,4,
                                            
                                            4,5,9,
                                            3,2,6,
                                            8,1,7,
                                            
                                            1,6,7,
                                            8,5,4,
                                            2,3,9 };
        public Hard1()
        {
            InitializeComponent();
        }
    }
}
