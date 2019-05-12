using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace Game
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GameWindow gamewindow = new GameWindow();
            gamewindow.Show();
            this.Close();
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow settingswindow = new SettingsWindow();
            settingswindow.Show();
            this.Close();
        }

        private void MainWindow_OnMouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = new Cursor($@"{Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()))}\Resources\arrow.cur");
        }
    }
}
