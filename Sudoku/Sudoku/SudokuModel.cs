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

        private string nuvarandeGrid;



        /*****************************************************
         * ANROP:   Rätta( inmatade siffror i array );
         * UPPGIFT: Kontrollerar inmatade siffror med de rätta
                    och markerar siffror röda och gröna.
         ******************************************************/
        public void Rätta() 
        { 
        
        }

        /**************************************************************************
         * ANROP:   PrintGrid( vilken radiobutton som är markerad );
         * UPPGIFT: Läser in vilken svårighetsgrad som är markerad och skriver
                    ut i GridPrint-usercontrol, sparar grid i globala nuvarandeGrid.
         **************************************************************************/
        public void PrintGrid() 
        { 
        
        }

    }

    // string array, tom ruta = " "
    // när den skriver in -> sätt IsEnabled="False", Foreground="Gray", FontWeight="ExtraBold"

    

}
