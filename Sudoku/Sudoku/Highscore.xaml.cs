using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Resources;
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
			readinHighscore();
		}

        void readinHighscore()      // Ska göra så att highscore läses in varje gång Sudoku startar
        {
            int rowsLength;
            int rowColumnsLength;

            //////////////// E A S Y ////////////////
            string path = @"C:\\Users\Ida\Documents\Heasy.txt";
            rowsLength = File.ReadLines(path).Count();
            if (rowsLength > 0)
            {
                string[] easy = new string[rowsLength];

                for (int i = 0; i < rowsLength; i++)
                {
                    using (StreamReader sr = File.OpenText(path))
                        easy[i] = sr.ReadLine();
                }

                rowColumnsLength = easy[0].Split(';').ToArray<string>().Length;

                for (int i = 0; i < rowsLength; i++)
                {
                    TableRow row = new TableRow();

                    string[] rowColumns = new string[rowColumnsLength];
                    rowColumns = easy[i].Split(';').ToArray<string>();

                    for (int j = 0; j < rowColumns.Length; j++)
                    {
                        row.Cells.Add(new TableCell(new Paragraph(new Run(rowColumns[j]))));
                    }
                    row.Cells[0].ColumnSpan = 2;
                    winnersListEasy.Rows.Add(row);
                }
            }

            /////////////// M E D I U M ///////////////
            path = @"C:\\Users\Ida\Documents\Hmedium.txt";
            rowsLength = File.ReadAllLines(path).Count();
            if (rowsLength > 0)
            {
                string[] medium = new string[rowsLength];

                for (int i = 0; i < rowsLength; i++)
                {
                    using (StreamReader sr = File.OpenText(path))
                        medium[i] = sr.ReadLine();
                }

                rowColumnsLength = medium[0].Split(';').ToArray<string>().Length;

                for (int i = 0; i < rowsLength; i++)
                {
                    TableRow row = new TableRow();

                    string[] rowColumns = new string[rowColumnsLength];
                    rowColumns = medium[i].Split(';').ToArray<string>();

                    for (int j = 0; j < rowColumnsLength; j++)
                    {
                        row.Cells.Add(new TableCell(new Paragraph(new Run(rowColumns[j]))));
                    }
                    row.Cells[0].ColumnSpan = 2;
                    winnersListMedium.Rows.Add(row);
                }
            }

            ///////////////// H A R D //////////////////
            path = @"C:\\Users\Ida\Documents\Hhard.txt";
            rowsLength = File.ReadAllLines(path).Count();
            if (rowsLength > 0)
            {
                string[] hard = new string[rowsLength];
                for (int i = 0; i < rowsLength; i++)
                {
                    using (StreamReader sr = File.OpenText(path))
                        hard[i] = sr.ReadLine();
                }

                rowColumnsLength = hard[0].Split(';').ToArray<string>().Length;

                for (int i = 0; i < rowsLength; i++)
                {
                    TableRow row = new TableRow();

                    string[] rowColumns = new string[rowColumnsLength];
                    rowColumns = hard[i].Split(';').ToArray<string>();

                    for (int j = 0; j < rowColumnsLength; j++)
                    {
                        row.Cells.Add(new TableCell(new Paragraph(new Run(rowColumns[j]))));
                    }

                    row.Cells[0].ColumnSpan = 2;
                    winnersListHard.Rows.Add(row);
                }
            }
        }

        void saveHighscore(string difficulty)        // Highscore sparas i en textfil varje gång en ny highscore läggs till
		{
            int rows;
            int cells = highscoreHeader.Rows[0].Cells.Count();
            string path;

			if (difficulty == "e")
			{
                path = @"C:\\Users\Ida\Documents\Heasy.txt";
                rows = winnersListEasy.Rows.Count();

                using (StreamWriter sw = File.CreateText(path))
                    sw.Write("");

                string[] highscoreEasy = new string[rows];

				for (int i = 0; i < rows; i++)
				{
					for (int j = 0; j < cells; j++)
					{
						highscoreEasy[i] += ((Run)((Paragraph)winnersListEasy.Rows[i].Cells[j].Blocks.FirstBlock).Inlines.FirstInline).Text;

						if (j != cells - 1)                  
							highscoreEasy[i] += ";";
					}
                    using (StreamWriter sw = File.AppendText(path))
						sw.WriteLine(highscoreEasy[i]);
				}
			}



			if (difficulty == "m")
			{
                path = @"C:\\Users\Ida\Documents\Hmedium.txt";
                rows = winnersListMedium.Rows.Count();

                using (StreamWriter sw = File.CreateText(path))
                    sw.Write("");

				string[] highscoreMedium = new string[rows];

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cells; j++)
                    {
                        highscoreMedium[i] += ((Run)((Paragraph)winnersListMedium.Rows[i].Cells[j].Blocks.FirstBlock).Inlines.FirstInline).Text;

                        if (j != cells - 1)
                            highscoreMedium[i] += ";";
                    }
                    using (StreamWriter sw = File.AppendText(path))
                        sw.WriteLine(highscoreMedium[i]);
                }
			}



			if (difficulty == "h")
			{
                path = @"C:\\Users\Ida\Documents\Hhard.txt";
                rows = winnersListHard.Rows.Count();
				
                using (StreamWriter sw = File.CreateText(path))
                    sw.Write("");

                string[] highscoreHard = new string[rows];

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cells; j++)
                    {
                        highscoreHard[i] += ((Run)((Paragraph)winnersListHard.Rows[i].Cells[j].Blocks.FirstBlock).Inlines.FirstInline).Text;

                        if (j != cells - 1)
                            highscoreHard[i] += ";";
                    }
                    using (StreamWriter sw = File.AppendText(path))
                    sw.WriteLine(highscoreHard[i]);
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

				saveHighscore("e");
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

				saveHighscore("m");
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

				saveHighscore("h");
			}

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
