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
    /// Interaction logic for Medium1.xaml
    /// </summary>
    public partial class Medium1 : UserControl
    {
        int[] _solutionMedium1 = new int[81] {5,2,7,
                                              1,8,9,
                                              6,3,4,

                                              8,1,9,
                                              4,6,3,
                                              7,5,2,
                                              
                                              3,6,4,
                                              2,5,7,
                                              1,9,8,
                                              
                                              9,5,1,
                                              2,7,3,
                                              8,4,6,
                                              
                                              3,2,7,
                                              6,4,8,
                                              5,9,1,
                                              
                                              8,4,6,
                                              9,1,5,
                                              7,3,2,
                                              
                                              4,1,2,
                                              3,9,5,
                                              7,6,8,
                                              
                                              9,7,6,
                                              2,8,4,
                                              1,3,5,
                                              
                                              5,8,3,
                                              6,7,1,
                                              4,2,9};
       
    public Medium1()
        {
            InitializeComponent();
        }
    }
}
