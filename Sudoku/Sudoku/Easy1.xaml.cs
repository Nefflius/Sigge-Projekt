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
    /// Interaction logic for Easy1.xaml
    /// </summary>
    public partial class Easy1 : UserControl
    {
        int[] _solutionEasy1 = new int[81] {6,9,3,   
                                            5,1,4,
                                            2,8,7,
                                            
                                            7,1,4,
                                            8,2,3,
                                            6,9,5,
                                            
                                            5,8,2,
                                            9,7,6,
                                            1,4,3,
                                            
                                            7,4,2,
                                            9,6,8,
                                            1,3,5,
                                            
                                            9,8,1,
                                            3,5,2,
                                            4,6,7,
                                            
                                            6,3,5,
                                            4,1,7,
                                            2,9,8,
                                            
                                            3,5,9,
                                            8,7,6,
                                            4,2,1,
                                            
                                            1,7,6,
                                            2,4,9,
                                            5,3,8,
                                            
                                            8,2,4,
                                            3,5,1,
                                            7,6,9 };
        public Easy1()
        {
            InitializeComponent();
        }

        public void SetDefaultNumbers()
        {
 
        }

    }
}
