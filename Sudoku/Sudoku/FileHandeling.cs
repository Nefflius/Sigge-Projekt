using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Win32;
using System.IO;
namespace Sudoku
{
    class FileHandeling
    {
        string _filePath;

        public FileHandeling(string filepath)
        {
            _filePath = filepath;
        }
        public string[] OpenFile()
        {
            string[] _sudokuElements = new string[3];
            bool _openFileSuccess;
            
            OpenFileDialog _openSudoku = new OpenFileDialog();
            
            if(Directory.Exists(_filePath))
                _openSudoku.InitialDirectory = _filePath;
            else
                _openSudoku.InitialDirectory = @"C:\";
            _openSudoku.DefaultExt = ".sdk";
            _openSudoku.Filter = "Sudokufiler (.sdk)|*.sdk";
            _openSudoku.FileName = "SparadSudoku.sdk";
             _openFileSuccess = (bool)_openSudoku.ShowDialog();
             if (_openFileSuccess)
             {
                 _filePath = _openSudoku.FileName;
                 StreamReader _readSavedGame = new StreamReader(_filePath);
                 
                 for (int i = 0; i < 3; i++)
                 {
                     _sudokuElements[i] = _readSavedGame.ReadLine();
                 }
             }
            return _sudokuElements;
        }

    }

}
