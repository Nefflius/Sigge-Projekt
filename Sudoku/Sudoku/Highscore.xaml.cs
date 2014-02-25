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
    /// Interaction logic for Highscore.xaml
    /// </summary>
    public partial class Highscore : UserControl
    {
        public Highscore()
        {
            InitializeComponent();
        }

        void readinHighscore()      // Ska göra så att highscore läses in varje gång Sudoku startar
        {
            
        }

        void saveHighscore()        // Ska göra så att highscore sparas i en textfil varje gång 
                                    // en ny highscore läggs till
        {
            int rows, cells;

            rows = winnersListEasy.Rows.Count();
            string[] highscoreEasy = new string[rows];

            for (int i = 0; i < rows; i++)
            {
                cells = winnersListEasy.Rows[i].Cells.Count();
                for (int j = 0; j < cells; j++)
                {
                    highscoreEasy[i] = winnersListEasy.Rows[i].Cells[j].ToString();     // fungerar ej

                    if (j != cells-1)           // så att den inte skriver ":" i slutet 
                        highscoreEasy[i] += ":";            // highscoreEasy[i] blir: namn:bana:drag:tid
                }
            }
          //System.IO.File.WriteAllLines(Properties.Resources.EasyHighscore_sdk, highscoreEasy);

            rows = winnersListMedium.Rows.Count();
            string[] highscoreMedium = new string[rows];

            for (int i = 0; i < rows; i++)
            {
                cells = winnersListMedium.Rows[i].Cells.Count();
                for (int j = 0; j < cells; i++)
                {
                    highscoreMedium[i] = winnersListMedium.Rows[i].Cells[j].ToString();

                    if (j != cells-1)
                        highscoreMedium[i] += ":";
                }
            }


            rows = winnersListHard.Rows.Count();
            string[] highscoreHard = new string[rows];

            for (int i = 0; i < rows; i++)
            {
                cells = winnersListHard.Rows[i].Cells.Count();
                for (int j = 0; j < cells; i++)
                {
                    highscoreHard[i] = winnersListHard.Rows[i].Cells[j].ToString();

                    if (j != cells-1)
                        highscoreHard[i] += ":";
                }
            }
        }

        public void addHighscore(string nameinput, string difficulty, string time, string moves)
        {
            TableRow row = new TableRow();

            // eftersom man valt svårighet på highscore så skrivs bara 1,2,3 ut alltså vilken bana man valt
            if (difficulty[0] == 'e')
            {
                difficulty = difficulty.Remove(0, 4);
                rbL.IsChecked = true;

                row.Cells.Add(new TableCell(new Paragraph(new Run(nameinput))));
                row.Cells.Add(new TableCell(new Paragraph(new Run(difficulty))));
                row.Cells.Add(new TableCell(new Paragraph(new Run(moves))));
                row.Cells.Add(new TableCell(new Paragraph(new Run(time))));
                row.Cells[0].ColumnSpan = 2;

                winnersListEasy.Rows.Add(row);

                highscoreListEasy.Visibility = Visibility.Visible;
                rbGrid.Margin = new Thickness(0, 0, 0, 0);
            }
            else if (difficulty[0] == 'm')
            {
                difficulty = difficulty.Remove(0, 6);
                rbM.IsChecked = true;

                row.Cells.Add(new TableCell(new Paragraph(new Run(nameinput))));
                row.Cells.Add(new TableCell(new Paragraph(new Run(difficulty))));
                row.Cells.Add(new TableCell(new Paragraph(new Run(moves))));
                row.Cells.Add(new TableCell(new Paragraph(new Run(time))));
                row.Cells[0].ColumnSpan = 2;

                winnersListMedium.Rows.Add(row);

                highscoreListMedium.Visibility = Visibility.Visible;
                rbGrid.Margin = new Thickness(0, 0, 0, 0);
            }
            else
            {
                difficulty = difficulty.Remove(0, 4);
                rbS.IsChecked = true;

                row.Cells.Add(new TableCell(new Paragraph(new Run(nameinput))));
                row.Cells.Add(new TableCell(new Paragraph(new Run(difficulty))));
                row.Cells.Add(new TableCell(new Paragraph(new Run(moves))));
                row.Cells.Add(new TableCell(new Paragraph(new Run(time))));
                row.Cells[0].ColumnSpan = 2;

                winnersListHard.Rows.Add(row);

                highscoreListHard.Visibility = Visibility.Visible;
                rbGrid.Margin = new Thickness(0, 0, 0, 0);
            }

            saveHighscore();

            var main = Application.Current.MainWindow as MainWindow;
            main.spelplanComponent.Visibility = Visibility.Collapsed;
            main.gridPrintComponent.Visibility = Visibility.Collapsed;
            main.highscoreComponent.Visibility = Visibility.Visible;
        }

        private void rb_Click(object sender, RoutedEventArgs e)
        {
            rbGrid.Margin = new Thickness(0, 0, 0, 0);
            if (Convert.ToBoolean(rbL.IsChecked))
            {
                highscoreListEasy.Visibility = Visibility.Visible;
                highscoreListMedium.Visibility = Visibility.Collapsed;
                highscoreListHard.Visibility = Visibility.Collapsed;
            }
            else if (Convert.ToBoolean(rbM.IsChecked))
            {
                highscoreListEasy.Visibility = Visibility.Collapsed;
                highscoreListMedium.Visibility = Visibility.Visible;
                highscoreListHard.Visibility = Visibility.Collapsed;
            }
            else if (Convert.ToBoolean(rbS.IsChecked))
            {
                highscoreListEasy.Visibility = Visibility.Collapsed;
                highscoreListMedium.Visibility = Visibility.Collapsed;
                highscoreListHard.Visibility = Visibility.Visible;
            }
        }

        private void clickOK(object sender, RoutedEventArgs e)
        {
            var main = Application.Current.MainWindow as MainWindow;
            main.highscoreComponent.Visibility = Visibility.Collapsed;
            main.highscoreComponent.highscoreListEasy.Visibility = Visibility.Collapsed;
            main.highscoreComponent.highscoreListMedium.Visibility = Visibility.Collapsed;
            main.highscoreComponent.highscoreListHard.Visibility = Visibility.Collapsed;
            main.highscoreComponent.rbGrid.Margin = new Thickness(0, 0, 0, 360);

            main.menuComponent.Visibility = Visibility.Visible;
        }
    }
}
