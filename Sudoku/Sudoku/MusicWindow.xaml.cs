﻿using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace Sudoku
{
    /// <summary>
    /// Interaction logic for MusicWindow.xaml
    /// </summary>
    public partial class MusicWindow : Window
    {
        public MusicWindow()
        {
            InitializeComponent();
        }

        private void Tack_Click(object sender, RoutedEventArgs e)
        {
            var main = Application.Current.MainWindow as MainWindow;
            
            main.spelplanComponent.StartTimer();
            main.MusicCheck = true;
            main.IsEnabled = true;

            this.Close();
        }

        private void Avbryt_Click(object sender, RoutedEventArgs e)
        {
            var main = Application.Current.MainWindow as MainWindow;
            
            main.spelplanComponent.StartTimer();
            main.MusicCheck = false;
            main.IsEnabled = true;

            this.Close();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            var main = Application.Current.MainWindow as MainWindow;

            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Musik.mp3"))
            {
                main.wplayer.URL = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Musik.mp3";
                main.wplayer.settings.setMode("loop", true);
                main.wplayer.controls.play();

                btnTack.IsEnabled = true;
                main.spelplanComponent.btnMusicOn.Visibility = Visibility.Visible;
                main.spelplanComponent.btnMusicOff.Visibility = Visibility.Hidden;
                main.mnuMusik.IsChecked = true;

                btnStart.Content = "Success!";
            }
            else
            {
                btnStart.Content = "Försök igen";
            }
        }
    }
}
