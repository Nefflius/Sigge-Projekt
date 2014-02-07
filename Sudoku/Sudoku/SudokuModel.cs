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

        int[] easySolution = new int[81] {6,1,3, 7,9,4, 5,8,2,
                                          5,8,4, 1,2,3, 9,7,6,
                                          2,9,7, 6,8,5, 1,4,3,
                                          7,4,2, 9,5,1, 6,3,8,
                                          9,6,5, 8,3,2, 4,1,7,
                                          1,3,8, 4,6,7, 2,9,5,
                                          4,5,1, 3,7,6, 8,2,9,
                                          8,7,6, 2,4,9, 3,5,1,
                                          3,2,9, 5,1,8, 7,6,4};


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

        
        string difficulty;

        /**************************************************************************
         * ANROP:   PrintGrid( vilken radiobutton som är markerad );
         * UPPGIFT: Läser in vilken svårighetsgrad som är markerad och skriver
                    ut i GridPrint-usercontrol, sparar grid i globala nuvarandeGrid.
         **************************************************************************/
        public void PrintGrid(string radioButtonChecked) 
        {          
            string[] useThisGrid = new string[81];
            GridPrint gridprint = new GridPrint();

            // när det finns flera spelplaner, randomiza fram vilken av dom som ska visas.

            switch (radioButtonChecked)
            {
                case "easy":
                    useThisGrid = easy;
                    difficulty = "easy";
                    break;
                case "medium":
                    useThisGrid = medium;
                    difficulty = "medium";
                    break;
                case "hard":
                    useThisGrid = hard;
                    difficulty = "hard";
                    break;
                default:
                    useThisGrid = radioButtonChecked.Select(c => c.ToString()).ToArray();
                    break;
            }
            
            gridprint.PrintGrid(useThisGrid);
            
        }

        /*****************************************************
         * ANROP:   Rätta( array med inmatade siffror );
         * UPPGIFT: Jämför inmatade siffror med de rätta siffrorna.
         ******************************************************/
        public void Rätta(string[] inmatade)
        {
            int[] solution = new int[81];

            switch (difficulty)
            {
                case "easy":
                    solution = easySolution;
                    break;  
            }

            // Konverterar inmatade sträng-array till en int-array (alltså jämförbar med solution)
            int[] inmatad = Array.ConvertAll(inmatade, int.Parse);
            
            // Skapar en array med bool där rätta siffror är true och falska false
            bool[] rättad = new bool[81];

            // Jämför inmatade siffror i array med rätta siffror i array,
            for (int i = 0; i < 81; i++)
            {
                if (inmatad[i] == solution[i])
                    rättad[i] = true;
                else
                    rättad[i] = false;
            }

            // Skickar denna array till MarkeraSiffror i GridPrint
            GridPrint gp = new GridPrint();
            gp.MarkeraSiffror(rättad);
        }
    }
}
