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
		public GridPrint()
		{
			InitializeComponent();  
		}
		public int antalDrag = 0;


        //Skriver ut lösning
        public void PrintSolution(int[] solution)
        {
            for (int i = 0; i < 81; i++)
            {
                TextBox tb = (TextBox)nameGridPrint.Children[i];
                tb.Text = solution[i].ToString();
                tb.IsEnabled = false;
            }
        }



        /*****************************************************
        ANROP:      PrintGrid(string[]);
        UPPGIFT:    Tar emot array med spelplan-siffror, 
                    skriver ut spelplan i GridPrint-usercontrol.
        ******************************************************/
        public GridPrint PrintGrid(string[] startUpBoard, string[] savedGame)
		{
            for (int i = 0; i < 81; i++)            // Tömmer spelplanen
            {
                TextBox tb = (TextBox)nameGridPrint.Children[i];
                tb.Text = "";
                tb.IsEnabled = true;
            }

            antalDrag = 0;                          // Återställer antal drag innan nytt spel
            var main = Application.Current.MainWindow as MainWindow;
            
            main.spelplanComponent.lblAntalDrag.Content = antalDrag;

			for (int i = 0; i < 81; i++)
			{
				TextBox textbox = (TextBox) nameGridPrint.Children[i];

                string savedGameCell = savedGame[i];
                string startUpBoardCell = startUpBoard[i];
                
                if (startUpBoardCell != " ")
                {
                    textbox.IsEnabled = false;
                    textbox.Background = Brushes.White;
                    textbox.Foreground = Brushes.Black;
                    textbox.BorderBrush = Brushes.Gray;
                    textbox.FontWeight = FontWeights.ExtraBold;

                    textbox.Text = startUpBoard[i];
                }
                else
                {
                    textbox.FontWeight = FontWeights.Normal;
                    textbox.Foreground = Brushes.Black;
                    textbox.BorderBrush = Brushes.Silver;
                    textbox.Text = savedGameCell.Trim();
                }
			}
			return this;
		}
        
		/****************************************************************
		ANROP:      Rätta();
		UPPGIFT:    Kontrollerar om alla textbox är ifyllda, skickar dem
					isåfall till Rättafunktion i Sudokumodel.
		*****************************************************************/
		public void Rätta(GridPrint gridprint) 
		{
			string[] arr = new string[81];
			for (int i = 0; i < 81; i++)  // Läser in alla textbox och lägger i en array
			{
				TextBox tb = (TextBox)nameGridPrint.Children[i];
				arr[i] = tb.Text;
			}

			SudokuModel model = new SudokuModel();
			model.Rätta(arr, gridprint);               // skicka till Rätta-funktion i Sudokumodel                      
		}
		
		/*****************************************************************
		ANROP:      MarkeraSiffror(bool[]);
		UPPGIFT:    Markerar rätta siffror med grönt och felaktiga med rött.
		******************************************************************/
		public void MarkeraSiffror(bool[] array)
		{
            int numGreen = 0;
            var main = Application.Current.MainWindow as MainWindow;

			for (int i = 0; i < 81; i++)
			{
				TextBox tb = (TextBox)nameGridPrint.Children[i];

				tb.IsEnabled = false;               // Låser textboxarna när rätta är klickad
				tb.BorderBrush = Brushes.Gray;      // Färgar textboxarna mörkgråa eftersom de får ljusgrå som default när de är låsta...

                if (array[i])
                {
                    tb.Foreground = Brushes.Green;
                    numGreen++;
                }
                else
                    tb.Foreground = Brushes.Red;
			}

            if (numGreen == 81)
            {
                main.gridPrintComponent.youMadeIt.Visibility = Visibility.Visible;
                highscoreTimer.Content = main.spelplanComponent.timer.Text;

                // Något roligt händer eftersom användare vunnit!!
                    // Flyttas från en koordinat till en annan, windows fixar animation...?
            }
		}

        
        public StringBuilder SaveGame()
        {
            StringBuilder strbSaveGame = new StringBuilder();
            for (int i = 0; i < 81; i++)
            {
                TextBox tb = (TextBox)nameGridPrint.Children[i];
                if (tb.Text == "")
                    strbSaveGame.Append(" ");
                else
                     strbSaveGame.Append(tb.Text);
            }
            return strbSaveGame;
        }

		public void continueGame()
		{
			var main = Application.Current.MainWindow as MainWindow;

			for (int i = 0; i < 81; i++)
			{
				TextBox textbox = (TextBox)nameGridPrint.Children[i];

				if (textbox.FontWeight == FontWeights.ExtraBold)
				{
					textbox.IsEnabled = false;
					textbox.Foreground = Brushes.Black;
				}
				else
				{
					textbox.IsEnabled = true;
					textbox.Foreground = Brushes.Black;
                    textbox.BorderBrush = Brushes.Silver;
				}
			}
			
		}

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (!char.IsDigit(e.Text, e.Text.Length - 1))           //Tar bort alla bokstäver som försöks skrivas in.
                e.Handled = true;
            else if (e.Text == "0")                                 //Tar bort siffran "0"
                e.Handled = true;
            else if (e.Text == tb.Text)
                e.Handled = true;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            

            var main = Application.Current.MainWindow as MainWindow;

            TextBox teb = (TextBox)sender;

            if (teb.Text != null)       // Automarkerar ifylld text
                teb.SelectAll();

            if (teb.BorderBrush != Brushes.Gray)
            {
                if (teb.Text != "")
                {
                    antalDrag++;
                    main.spelplanComponent.lblAntalDrag.Content = antalDrag;
                }
            }


            // Läser av alla rutor, om alla är ifyllda, rätta!
            for (int i = 0; i < 81; i++) 
            {
                TextBox tb = (TextBox)main.gridPrintComponent.nameGridPrint.Children[i];

                if (tb.Text == "") // om en textbox är tom är rätta-knapp likadan
                {
                    main.spelplanComponent.btnRätta.IsEnabled = false;
                    main.spelplanComponent.btnRätta.Effect = new System.Windows.Media.Effects.DropShadowEffect() { Opacity = 0.5 };
                    return;
                }
                else // om alla är ifyllda, rätta-knapp isEnabled och skugga tydligare..
                {
                    main.spelplanComponent.btnRätta.IsEnabled = true;
                    main.spelplanComponent.btnRätta.Effect = new System.Windows.Media.Effects.DropShadowEffect() { Opacity = 0.8 };
                }
            }
        }


        //Navigaion using arrows
        /*****************************************************************************************
         This will help to navigate between the cells of the grid by pressing the keyboard arrows
          
        **************************************************************************************/
        private void Viewbox_PreviewKeyDown_1(object sender, KeyEventArgs e)
        {
            Action<FocusNavigationDirection> moveFocus = focusDirection =>
            {
                e.Handled = true;
                var request = new TraversalRequest(focusDirection);
                var focusedElement = Keyboard.FocusedElement as UIElement;
                if (focusedElement != null)
                    focusedElement.MoveFocus(request);
            };

            switch (e.Key)
            {
                case Key.Left:
                    moveFocus(FocusNavigationDirection.Previous);
                    break;
                case Key.Right:
                    moveFocus(FocusNavigationDirection.Next);
                    break;
                case Key.Up:
                    moveFocus(FocusNavigationDirection.Up);
                    break;
                case Key.Down:
                    moveFocus(FocusNavigationDirection.Down);
                    break;
                default:
                    break;
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Background = Brushes.Black;
            tb.Foreground = Brushes.White;
            tb.FontWeight = FontWeights.Heavy;
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Background = Brushes.White;
            tb.Foreground = Brushes.Black;
            tb.FontWeight = FontWeights.Normal;
        }

        private void clickOK(object sender, RoutedEventArgs e)  // OK i highscore-input
        {
            var main = Application.Current.MainWindow as MainWindow;
            
            main.spelplanComponent.GameWon(nameInput.Text.ToString(), highscoreTimer.Content.ToString());
            main.spelplanComponent.btnRätta.Content = "RÄTTA";
            
            youMadeIt.Visibility = Visibility.Hidden;
        }
	}
}
