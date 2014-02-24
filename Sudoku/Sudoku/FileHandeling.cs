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

        public FileHandeling()
        {
            _filePath = Environment.SpecialFolder.MyDocuments.ToString();
            _filePath += "\\Sparade sudokospel";
            if (!Directory.Exists(_filePath))
                CreateFolder();


        }

        public void CreateFolder()
        {
            try
            {
                DirectoryInfo _folder4SavedGames = Directory.CreateDirectory(_filePath);
            }
            
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }
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
                 using (StreamReader _readSavedGame = File.OpenText(_filePath))
                 {
                     for (int i = 0; i < 3; i++)
                     {
                         _sudokuElements[i] = _readSavedGame.ReadLine();
                     }
                 }
             }
            return _sudokuElements;
        }

        public void SaveFile(string[] _arrayElements2Save)
        {
            bool _saveFilesuccess;
            SaveFileDialog _saveSudoku = new SaveFileDialog();
            _saveSudoku.Filter = "Sudokufiler (.sdk)|*.sdk";
            _saveSudoku.Filter = "Sudokufiler (.sdk)|*.sdk";
            _saveSudoku.FileName = "SparadSudoku.sdk";
            _saveSudoku.DefaultExt = ".sdk";
            _saveFilesuccess = (bool)_saveSudoku.ShowDialog();
            if (_saveFilesuccess)
            {
                //string 
                using (StreamWriter save2File = new StreamWriter(_saveSudoku.FileName))
                {
                    save2File.WriteLine(_arrayElements2Save[0]);
                    save2File.WriteLine(_arrayElements2Save[1]);
                    save2File.WriteLine(_arrayElements2Save[2]);
                }
                System.Windows.MessageBox.Show("Spelet har sparats!", "Spelet har sparats", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
            }
        }
    }
}
