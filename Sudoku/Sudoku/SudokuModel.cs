using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class SudokuModel
    {
        GridPrint objGridprint;
        string[] useThisGrid = new string[81];
        string[] editedNumbers = new string[81];

        string[] easy1 = new string[81]  { " ", " ", " ",     "7", " ", "4",     " ", "8", " ", 
                                          "5", " ", "4",     " ", "2", " ",     "9", "7", "6",  
                                          " ", " ", " ",     " ", " ", " ",     " ", " ", " ",
         
                                          " ", " ", "2",     "9", " ", "1",     "6", " ", " ",
                                          "9", "6", " ",     " ", " ", " ",     " ", "1", "7", 
                                          " ", " ", " ",     "4", " ", "7",     "2", " ", " ", 
        
                                          " ", " ", " ",     " ", " ", " ",     " ", " ", " ", 
                                          "8", "7", "6",     " ", "4", " ",     "3", " ", "1", 
                                          " ", "2", " ",     "5", " ", "8",     " ", " ", " " };

        int[] easy1Solution = new int[81] { 6,1,3, 7,9,4, 5,8,2,
                                           5,8,4, 1,2,3, 9,7,6,
                                           2,9,7, 6,8,5, 1,4,3,
                                           7,4,2, 9,5,1, 6,3,8,
                                           9,6,5, 8,3,2, 4,1,7,
                                           1,3,8, 4,6,7, 2,9,5,
                                           4,5,1, 3,7,6, 8,2,9,
                                           8,7,6, 2,4,9, 3,5,1,
                                           3,2,9, 5,1,8, 7,6,4 };

        string[] easy2 = new string[81] { " ", " ", "7",    "2", " ", "8",    "6", " ", " ",
                                          " ", "9", "3",    " ", "6", " ",    "8", "1", " ", 
                                          "6", "8", " ",    " ", "3", " ",    " ", "4", "2",
 
                                          " ", " ", " ",    "3", " ", "5",    " ", " ", " ",
                                          "4", " ", " ",    " ", " ", " ",    " ", " ", "6",
                                          " ", " ", " ",    "6", " ", "4",    " ", " ", " ",

                                          "9", "6", " ",    " ", "2", " ",    " ", "5", "8",
                                          " ", "3", "8",    " ", "4", " ",    "1", "2", " ",
                                          " ", " ", "2",    "5", " ", "3",    "4", " ", " " };

        int[] easy2Solution = new int[81] { 1,4,7, 2,5,8, 6,9,3,
                                            2,9,3, 4,6,7, 8,1,5,
                                            6,8,5, 1,3,9, 7,4,2,
                                            8,2,6, 3,1,5, 9,7,4,
                                            4,7,1, 8,9,2, 5,3,6,
                                            3,5,9, 6,7,4, 2,8,1,
                                            9,6,4, 7,2,1, 3,5,8,
                                            5,3,8, 9,4,6, 1,2,7,
                                            7,1,2, 5,8,3, 4,6,9 };

        string[] easy3 = new string[81] { " ", " ", "2",    " ", " ", "3",    " ", "1", "4",
                                          " ", " ", " ",    "5", " ", "1",    " ", " ", "7", 
                                          " ", " ", " ",    " ", "4", "2",    "9", " ", " ",
 
                                          "7", " ", "4",    "3", " ", "9",    "5", " ", "2",
                                          " ", "2", " ",    "8", " ", "4",    " ", "9", " ",
                                          "8", " ", " ",    " ", " ", " ",    " ", " ", "6",

                                          " ", " ", "1",    "2", "5", " ",    " ", " ", " ",
                                          "3", " ", " ",    "9", " ", "7",    " ", " ", " ",
                                          "2", "5", " ",    "4", " ", " ",    "7", " ", " " };

        int[] easy3Solution = new int[81] { 5,8,2, 7,9,3, 6,1,4,
                                            9,4,6, 5,8,1, 3,2,7,
                                            1,3,7, 6,4,2, 9,5,8,
                                            7,1,4, 3,6,9, 5,8,2,
                                            6,2,5, 8,7,4, 1,9,3,
                                            8,9,3, 1,2,5, 4,7,6,
                                            4,7,1, 2,5,6, 8,3,9,
                                            3,6,8, 9,1,7, 2,4,5,
                                            2,5,9, 4,3,8, 7,6,1 };

        string[] medium1 = new string[81] { " ", " ", " ",      " ", " ", "9",      " ", " ", "4", 
                                           " ", " ", "9",      "4", "6", " ",      " ", " ", "7",
                                           " ", "3", " ",      " ", " ", " ",      "1", " ", "8", 

                                           " ", "5", " ",      " ", "2", " ",      "8", " ", " ", 
                                           " ", " ", " ",      "6", " ", "8",      " ", " ", " ", 
                                           " ", " ", "6",      " ", "9", " ",      " ", "3", " ", 
        
                                           "4", " ", "2",      " ", " ", " ",      " ", "8", " ", 
                                           "3", " ", " ",      " ", "8", "4",      "6", " ", " ", 
                                           "7", " ", " ",      "1", " ", " ",      " ", " ", " " };

        int[] medium1Solution = new int[81] { 5,2,7, 8,1,9, 3,6,4,
                                              1,8,9, 4,6,3, 2,5,7,
                                              6,3,4, 7,5,2, 1,9,8,
                                              9,5,1, 3,2,7, 8,4,6,
                                              2,7,3, 6,4,8, 9,1,5,
                                              8,4,6, 9,5,1, 7,3,2,
                                              4,1,2, 9,7,6, 5,8,3,
                                              3,9,5, 2,8,4, 6,7,1, 
                                              7,6,8, 1,3,5, 4,2,9 };

        string[] medium2 = new string[81] { " ", " ", "2",    " ", " ", " ",    "5", "3", "8",    
                                            " ", "9", " ",    " ", " ", "5",    "1", "7", " ",    
                                            " ", " ", " ",    "3", " ", " ",    " ", " ", " ",
    
                                            "8", " ", " ",    " ", "7", "6",    " ", " ", " ",    
                                            " ", " ", " ",    "8", "9", "1",    " ", " ", " ",    
                                            " ", " ", " ",    "2", "4", " ",    " ", " ", "9",

                                            " ", " ", " ",    " ", " ", "7",    " ", " ", " ",    
                                            " ", "3", "7",    "6", " ", " ",    " ", "1", " ",    
                                            "4", "5", "6",    " ", " ", " ",    "9", " ", " "};

        int[] medium2Solution = new int[81] { 1,4,2,7,6,9,5,3,8,
                                              6,9,3,4,8,5,1,7,2,
                                              7,8,5,3,1,2,6,9,4,
                                              8,2,9,5,7,6,3,4,1,
                                              3,7,4,8,9,1,2,5,6,
                                              5,6,1,2,4,3,7,8,9,
                                              2,1,8,9,5,7,4,6,3,
                                              9,3,7,6,2,4,8,1,5,
                                              4,5,6,1,3,8,9,2,7 };

        string[] medium3 = new string[81] { " ", "3", " ",    " ", "1", "9",    " ", "7", "8",    
                                            " ", " ", " ",    " ", "6", " ",    " ", " ", "4",    
                                            " ", " ", " ",    " ", " ", " ",    " ", "5", "2",

                                            "1", " ", " ",    " ", " ", " ",    " ", " ", " ",    
                                            " ", " ", "9",    "4", " ", "6",    "7", " ", " ",    
                                            " ", " ", " ",    " ", " ", " ",    " ", " ", "3",

                                            "7", "9", " ",    " ", " ", " ",    "3", " ", " ",    
                                            "5", " ", " ",    " ", "8", " ",    " ", " ", " ",    
                                            "8", "6", " ",    "2", "3", " ",    " ", "9", " ",};

        int[] medium3Solution = new int[81]{ 2,3,4,5,1,9,6,7,8,
                                              9,7,5,8,6,2,1,3,4,
                                              6,1,8,3,7,4,9,5,2,
                                              1,5,6,7,2,3,8,4,9,
                                              3,8,9,4,5,6,7,2,1,
                                              4,2,7,1,9,8,5,6,3,
                                              7,9,2,6,4,1,3,8,5,
                                              5,4,3,9,8,7,2,1,6,
                                              8,6,1,2,3,5,4,9,7 };
  


        string[] hard1 = new string[81] { " ", "9", " ",     " ", "4", " ",     " ", "8", " ", 
                                          " ", "4", "2",     " ", "3", " ",     "6", "7", " ", 
                                          " ", " ", " ",     "6", " ", "2",     " ", " ", " ", 
        
                                          " ", " ", "7",     " ", " ", " ",     "5", " ", " ", 
                                          " ", "2", " ",     " ", "8", " ",     " ", "9", " ", 
                                          " ", " ", "8",     " ", " ", " ",     "7", " ", " ", 
        
                                          " ", " ", " ",     "4", " ", "9",     " ", " ", " ",
                                          " ", "7", "9",     " ", "2", " ",     "8", "5", " ",
                                          " ", "5", " ",     " ", "1", " ",     " ", "3", " " };

        int[] hard1Solution = new int[81] { 7,9,6, 1,4,5, 3,8,2,
                                            5,4,2, 9,3,8, 6,7,1,
                                            8,3,1, 6,7,2, 9,4,5,
                                            4,6,7, 2,9,3, 5,1,8,
                                            3,2,5, 7,8,1, 4,9,6,
                                            9,1,8, 5,6,4, 7,2,3,
                                            2,8,3, 4,5,9, 1,6,7,
                                            1,7,9, 3,2,6, 8,5,4, 
                                            6,5,4, 8,1,7, 2,3,9 };

        string[] hard2 = new string[81] { "1", " ", " ",     "8", " ", "6",     " ", " ", "3", 
                                          "3", " ", " ",     " ", " ", " ",     " ", " ", "2", 
                                          " ", "2", " ",     "1", " ", "3",     " ", "4", " ", 
        
                                          " ", "5", " ",     " ", " ", " ",     " ", "1", " ", 
                                          " ", " ", " ",     "4", " ", "7",     " ", " ", " ", 
                                          " ", "7", " ",     " ", " ", " ",     " ", "9", " ", 
        
                                          " ", "4", " ",     "6", " ", "8",     " ", "3", " ",
                                          "6", " ", " ",     " ", " ", " ",     " ", " ", "8", 
                                          "8", " ", " ",     "5", " ", "4",     " ", " ", "1" };

        int[] hard2Solution = new int[81] { 1,9,4, 8,2,6, 5,7,3,
                                            3,6,7, 9,4,5, 1,8,2,
                                            5,2,8, 1,7,3, 9,4,6,
                                            4,5,3, 2,8,9, 6,1,7,
                                            9,8,1, 4,6,7, 3,2,5,
                                            2,7,6, 3,5,1, 8,9,4,
                                            7,4,5, 6,1,8, 2,3,9,
                                            6,1,9, 7,3,2, 4,5,8,
                                            8,3,2, 5,9,4, 7,6,1 };

        string[] hard3 = new string[81] { " ", " ", " ",     " ", " ", " ",     " ", " ", " ", 
                                          "1", " ", " ",     "8", "5", " ",     "9", " ", " ", 
                                          "3", " ", " ",     " ", " ", "1",     "8", "5", " ", 
         
                                          "8", " ", "3",     "1", " ", " ",     " ", "7", " ", 
                                          " ", " ", " ",     "4", " ", "7",     " ", " ", " ", 
                                          " ", "1", " ",     " ", " ", "8",     "3", " ", "2", 
        
                                          " ", "9", "8",     "7", " ", " ",     " ", " ", "4",
                                          " ", " ", "2",     " ", "1", "5",     " ", " ", "6", 
                                          " ", " ", " ",     " ", " ", " ",     " ", " ", " " };

        int[] hard3Solution = new int[81] { 2,8,5, 3,7,9, 4,6,1,
                                            1,7,4, 8,5,6, 9,2,3,
                                            3,6,9, 2,4,1, 8,5,7,
                                            8,4,3, 1,9,2, 6,7,5,
                                            5,2,6, 4,3,7, 1,9,8,
                                            9,1,7, 5,6,8, 3,4,2,
                                            6,9,8, 7,2,3, 5,1,4,
                                            4,3,2, 9,1,5, 7,8,6,
                                            7,5,1, 6,8,4, 2,3,9 };

        public enum Difficulty { Easy, Medium, Hard };

        static string difficulty;
        static int[] solution = new int[81];

        static int checkanswers;
        private static bool sendanswers;
        
        public static bool send
        {
            get { return sendanswers; }
            set { sendanswers = value; }
        }

        // Skickar rätt array med lösning till Gridprint 
        public void fuska(GridPrint gridprint)
        {
            gridprint.PrintSolution(solution);
        }

        //public int CellNumber { get { return cellNumber; } set { cellNumber = value;} }

        public string GetSetGame2Save 
        { 
            get 
            {
                return objGridprint.SaveGame().ToString();
            } 
        }

        public string[] GetUseThisGrid { get { return useThisGrid;} }
        public string GetDifficulty { get { return difficulty;} }

        /**************************************************************************
         * ANROP:   PrintGrid( vilken radiobutton som är markerad );
         * UPPGIFT: Läser in vilken svårighetsgrad som är markerad och skriver
                    ut i GridPrint-usercontrol, sparar grid i globala nuvarandeGrid.
         **************************************************************************/
        public GridPrint PrintGrid(string radioButtonChecked, GridPrint gridprint, string[] savedGame = null )        
        {
            objGridprint = gridprint;
            difficulty = radioButtonChecked;

            switch (radioButtonChecked)
            {
                case "easy1":
                    useThisGrid = easy1;
                    solution = easy1Solution;
                    break;
                case "easy2":
                    useThisGrid = easy2;
                    solution = easy2Solution;
                    break;
                case "easy3":
                    useThisGrid = easy3;
                    solution = easy3Solution;
                    break;
                case "medium1":
                    useThisGrid = medium1;
                    solution = medium1Solution;
                    break;
                case "medium2":
                    useThisGrid = medium2;
                    solution = medium2Solution;
                    break;
                case "medium3":
                    useThisGrid = medium3;
                    solution = medium3Solution;
                    break;
                case "hard1":
                    useThisGrid = hard1;
                    solution = hard1Solution;
                    break;
                case "hard2":
                    useThisGrid = hard2;
                    solution = hard2Solution;
                    break;
                case "hard3":
                    useThisGrid = hard3;
                    solution = hard3Solution;
                    break;
                default:
                    useThisGrid = radioButtonChecked.Select(c => c.ToString()).ToArray();
                    break;
            }

            if (savedGame == null)
                savedGame = useThisGrid;

            return objGridprint.PrintGrid(useThisGrid, savedGame);
        }
       
        /*****************************************************
         * ANROP:   Rätta( array med inmatade siffror );
         * UPPGIFT: Jämför inmatade siffror med de rätta siffrorna.
         ******************************************************/
        public void Rätta(string[] inmatade, GridPrint gridprint)
        {
            // Konverterar inmatade sträng-array till en int-array (alltså jämförbar med solution)
            int[] inmatad = Array.ConvertAll(inmatade, int.Parse);
            
            // Skapar en array med bool där rätta siffror är true och falska false
            bool[] rättad = new bool[81];

            // Jämför inmatade siffror i array med rätta siffror i array,
            
            for (int i = 0; i < 81; i++)
            {
                if (inmatad[i] == solution[i])
                {
                    rättad[i] = true;
                    checkanswers++;
                }
                else
                    rättad[i] = false;              
            }

            if (checkanswers == 81)
            {
                sendanswers = true;
                checkanswers = 0;
            }
            else
            {
                sendanswers = false;
                checkanswers = 0;
            }


            // Skickar denna array till MarkeraSiffror i GridPrint
            gridprint.MarkeraSiffror(rättad);
        }

        public string getThisSolution()
        {
            return difficulty;
        }
    }
}
