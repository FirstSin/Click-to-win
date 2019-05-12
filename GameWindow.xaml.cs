using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using Path=System.IO.Path;
using System.Windows.Threading;
using WMPLib;

namespace Game
{
    public partial class GameWindow : Window
    {
        public int score = 0;
        public int bestscore = 0;
        Random rand = new Random();
        public DispatcherTimer timer;
        public DispatcherTimer timer2;
        public Image img_clone;
        public List<Image> imagecount;
        private WMPLib.WindowsMediaPlayer WMP;
        private WMPLib.WindowsMediaPlayer ClickSound;
        public GameWindow()
        {
            InitializeComponent();

            ClickSound = new WMPLib.WindowsMediaPlayer();
            ClickSound.URL = $@"{Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()))}\Track List\Click.mp3";
            imagecount = new List<Image>();
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(TimerTick);
            timer.Interval = new TimeSpan(0,0,0,0, 800);
            timer.Start();
            timer2 = new DispatcherTimer();
            timer2.Tick += new EventHandler(SpeedUpTimer);
            timer2.Interval = new TimeSpan(0,0,5);
            timer2.Start();
            Thread playmusic = new Thread(new ThreadStart(PlayMusic));
            playmusic.Start();
        }

        private void SpeedUpTimer(object sender, EventArgs e)
        {
            if (timer.Interval.TotalSeconds >= 0.35)
                timer.Interval -= new TimeSpan(0, 0, 0, 0, 50);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            GameOver();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            Image img = new Image();
            img.Source = new BitmapImage(new Uri(@"C:\Users\Sin\Downloads\round.png", UriKind.Absolute)); 
            img.Width = 150;
            img.Height = 150;
            img.Opacity = 100;
            img.Margin = new Thickness(rand.Next(0, 950), rand.Next(50, 500), rand.Next(0, 950), rand.Next(0, 500));
            img.MouseLeftButtonDown += new MouseButtonEventHandler(Ellipse_Click);
            MainPanel.Children.Add(img); //Add an ellipse in the random place;
            imagecount.Add(img);
            if (imagecount.Count >= 10)
            {
                GameOver();
            }

        }

        private void Ellipse_Click(object sender, MouseButtonEventArgs e)
        {
            ClickSound.controls.play();
            score++;
            ScoreText.Text = score.ToString();
            Image img = (Image)sender;
            img_clone = img;
            img.IsEnabled = false;

            DoubleAnimation ellipse_opacity = new DoubleAnimation();
            ellipse_opacity.From = Opacity;
            ellipse_opacity.To = 0.1;
            ellipse_opacity.Completed += new EventHandler(ImageRemove);
            ellipse_opacity.Duration = TimeSpan.FromSeconds(0.2);

            DoubleAnimation ellipse_size = new DoubleAnimation();
            ellipse_size.From = 150;
            ellipse_size.To = 200;
            ellipse_size.Completed += new EventHandler(ImageRemove);
            ellipse_size.Duration = TimeSpan.FromSeconds(0.2);

            img.BeginAnimation(Image.WidthProperty, ellipse_size);
            img.BeginAnimation(Image.HeightProperty, ellipse_size);
            img.BeginAnimation(Image.OpacityProperty, ellipse_opacity);
        }

        private void ImageRemove(object sender, EventArgs e)
        {
            if(img_clone != null)
                MainPanel.Children.Remove(img_clone);
            if (imagecount != null)
                imagecount.Remove(img_clone);
        }

        private void GameOver()
        {
            timer.Stop();
            timer2.Stop();
            WMP.controls.stop();
            MessageBox.Show($"Game over \n Your score: {score}");
            score = 0;
            for (var i = 0; i < imagecount.Count; i++)
                imagecount.RemoveAt(i);
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void RemoveFromMainPanel(Image img)
        {
            MainPanel.Children.Remove(img);
        }

        private void PlayMusic()
        {
            WMP = new WMPLib.WindowsMediaPlayer();
            WMP.URL = $@"{Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()))}\Track List\{rand.Next(1, 7)}.mp3";
            WMP.controls.play();
        }

        private void GameWindow_OnMouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = new Cursor($@"{Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()))}\Resources\arrow.cur");
        }
    }
}
