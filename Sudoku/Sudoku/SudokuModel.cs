using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class SudokuModel
    {
        string[] easy = new string[81] { " ", " ", " ",     "7", " ", "4",     " ", "8", " ", 
                                         "5", " ", "4",     " ", "2", " ",     "9", "7", "6",  
                                         " ", " ", " ",     " ", " ", " ",     " ", " ", " ",
        
                                         " ", " ", "2",     "9", " ", "1",     "6", " ", " ",
                                         "9", "6", " ",     " ", " ", " ",     " ", "1", "7", 
                                         " ", " ", " ",     "4", " ", "7",     "2", " ", " ", 
        
                                         " ", " ", " ",     " ", " ", " ",     " ", " ", " ", 
                                         "8", "7", "6",     " ", "4", " ",     "3", " ", "1", 
                                         " ", "2", " ",     "5", " ", "8",     " ", " ", " ", };


        string[] medium = new string[81] { " ", " ", " ",       " ", " ", "9",      " ", " ", "4", 
                                           " ", " ", "9",       "4", "6", " ",      " ", " ", "7",
                                           " ", "3", " ",       " ", " ", " ",      "1", " ", "8", 

                                           " ", "5", " ",       " ", "2", " ",      "8", " ", " ", 
                                           " ", " ", " ",       "6", " ", "8",      " ", " ", " ", 
                                           " ", " ", "6",       " ", "9", " ",      " ", "3", " ", 
        
                                           "4", " ", "2",       " ", " ", " ",      " ", "8", " ", 
                                           "3", " ", " ",       " ", "8", "4",      "6", " ", " ", 
                                           "7", " ", " ",       "1", " ", " ",      " ", " ", " ", };


        string[] hard = new string[81] { " ", "9", " ",     " ", "4", " ",     " ", "8", " ", 
                                         " ", "4", "2",     " ", "3", " ",     "6", "7", " ", 
                                         " ", " ", " ",     "6", " ", "2",     " ", " ", " ", 
        
                                         " ", " ", "7",     " ", " ", " ",     "5", " ", " ", 
                                         " ", "2", " ",     " ", "8", " ",     " ", "9", " ", 
                                         " ", " ", "8",     " ", " ", " ",     "7", " ", " ", 
        
                                         " ", " ", " ",     "4", " ", "9",     " ", " ", " ",
                                         " ", "7", "9",     " ", "2", " ",     "8", "5", " ", 
                                         " ", "5", " ",     " ", "1", " ",     " ", "3", " ", };

        public enum Difficulty { Easy, Medium, Hard };

        /**************************************************************************
         * ANROP:   PrintGrid( vilken radiobutton som är markerad );
         * UPPGIFT: Läser in vilken svårighetsgrad som är markerad och skriver
                    ut i GridPrint-usercontrol, sparar grid i globala nuvarandeGrid.
         **************************************************************************/
        public GridPrint PrintGrid(string radioButtonChecked) 
        {          
            string[] useThisGrid = new string[81];
            GridPrint gridprint = new GridPrint();

            // när det finns flera spelplaner, randomiza fram vilken av dom som ska visas.

            switch (radioButtonChecked)
            {
                case "easy":
                    useThisGrid = easy;
                    break;
                case "medium":
                    useThisGrid = medium;
                    break;
                case "hard":
                    useThisGrid = hard;
                    break;
            }

            GridPrint newGameboard = gridprint.PrintGrid(useThisGrid);
            return newGameboard;
        }

        /*****************************************************
         * ANROP:   Rätta( array med inmatade siffror );
         * UPPGIFT: Jämför inmatade siffror med de rätta siffrorna.
         ******************************************************/
        public void Rätta(string[] inmatade)
        {


            // Jämför inmatade siffror i array med rätta siffror i array,
            // Skapar en array med bool där rätta siffror är true och falska false
            // Skickar denna array till MarkeraSiffror i GridPrint
        }
    }
}
