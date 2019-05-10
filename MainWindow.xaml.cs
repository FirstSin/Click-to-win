using System;
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

namespace Game
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int musicbutton_count = 0;
        WMPLib.WindowsMediaPlayer WMP = new WMPLib.WindowsMediaPlayer();
        public MainWindow()
        {
            InitializeComponent();

            WMP.URL = @"D:\Visual Studio\Projects\Game\Music\song1.mp3";
            WMP.controls.play();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            if (musicbutton_count % 2 == 0)
            {
                WMP.controls.pause();
                musicOnIcon.Visibility = Visibility.Hidden;
                musicOffIcon.Visibility = Visibility.Visible;
            }
            else
            {
                WMP.controls.play();
                musicOffIcon.Visibility = Visibility.Hidden;
                musicOnIcon.Visibility = Visibility.Visible;
            }

            musicbutton_count += 1;
        }
    }
}
