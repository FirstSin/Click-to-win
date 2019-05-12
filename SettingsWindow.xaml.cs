using System;
using System.Collections.Generic;
using System.IO;
using Path=System.IO.Path;
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

namespace Game
{
    /// <summary>
    /// Логика взаимодействия для SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void SettingsWindow_OnMouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = new Cursor($@"{Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()))}\Resources\arrow.cur");
        }
    }
}
