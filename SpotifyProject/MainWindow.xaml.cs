using SpotifyProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
using System.Windows.Threading;

namespace SpotifyProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            timer.Tick += _timer_Tick;
        }


        private void StackPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            
            var stackPanel = sender as StackPanel;
            if (stackPanel != null)
            {
                SetFontWeight(stackPanel, FontWeights.UltraBold);
            }
        }

        private void StackPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            var stackPanel = sender as StackPanel;
            if (stackPanel != null)
            {
                SetFontWeight(stackPanel, FontWeights.Normal);
            }
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Xử lý sự kiện click ở đây
            var stackPanel = sender as StackPanel;
            if (stackPanel != null)
            {
                var stackPanelName = stackPanel.Name;

                // Thực hiện các hành động tương ứng với sự kiện click (ví dụ: hiển thị nội dung, chuyển trang, ...)
                switch (stackPanelName)
                {
                    case "homePanel":
                        MessageBox.Show("Home clicked!");
                        break;
                    case "searchPanel":
                        MessageBox.Show("Search clicked!");
                        break;
                    case "musicPanel":
                        mainFrame.Navigate(new Uri("Views/MusicPage.xaml", UriKind.Relative));
                        break;
                    case "videoPanel":
                        MessageBox.Show("Video clicked!");
                        break;
                    case "settingPanel":
                        MessageBox.Show("Setting clicked!");
                        break;
        
                }
            }
        }

        private void SetFontWeight(StackPanel stackPanel, FontWeight fontWeight)
        {
            var textBlock = stackPanel.Children.OfType<TextBlock>().FirstOrDefault();
            var icon = stackPanel.Children.OfType<FontAwesome.WPF.FontAwesome>().FirstOrDefault();

            if (textBlock != null && icon != null)
            {
                textBlock.FontWeight = fontWeight;
                icon.FontWeight = fontWeight;
            }
        }

        private void PlayIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(PlayerMediaService.IsPlaying)
            {
                PlayerMediaService.PauseSong();
                ChangeStateIcon();
                timer.Stop();
            } else if(PlayerMediaService.IsPaused)
            {
                PlayerMediaService.ContinueSong();
                ChangeStateIcon();
                timer.Start();
            }
            else if(PlayerMediaService.IsStopped)
            {
                PlayerMediaService.PlaySong(PlayerMediaService.player.URL);
                ChangeStateIcon();
                timer.Start();
            }
        }

        public void OnPlayPauseStateChanged(object sender, bool isPlaying)
        {
            if (isPlaying)
            {
                PlayIcon.Icon = FontAwesome.WPF.FontAwesomeIcon.Pause;
                SetCurrentSongInfo();

            }
            else
            {
                PlayIcon.Icon = FontAwesome.WPF.FontAwesomeIcon.Play;
                SetCurrentSongInfo();

            }
        }

        public void ChangeStateIcon()
        {
            if (PlayerMediaService.IsPlaying)
            {
                PlayIcon.Icon = FontAwesome.WPF.FontAwesomeIcon.Pause;
                SetCurrentSongInfo();
            }
            else if (PlayerMediaService.IsPaused)
            {
                PlayIcon.Icon = FontAwesome.WPF.FontAwesomeIcon.Play;
                SetCurrentSongInfo();
            }
            else if (PlayerMediaService.IsStopped)
            {
                PlayIcon.Icon = FontAwesome.WPF.FontAwesomeIcon.Play;
            }
        }

        public void SetCurrentSongInfo()
        {
            if(PlayerMediaService.CurrentSong != null)
            {
                nameSong.Text = PlayerMediaService.CurrentSong.Title;
                nameArtist.Text = PlayerMediaService.CurrentSong.Artist;
                EndDurationInfoSong.Text = PlayerMediaService.CurrentSong.Length;
            }
          
        }


        private DispatcherTimer timer;
        public void OnSongChanged(object sender)
        {
            UpdateDurationInfo();
        }

        public void UpdateDurationInfo()
        {
            if (PlayerMediaService.CurrentSong != null && PlayerMediaService.player != null)
            {

                int currentPosition = PlayerMediaService.GetCurrentSongPosition();

                if(currentPosition % 60 < 10)
                {
                    DurationInfoSong.Text = $"{currentPosition / 60}:0{(currentPosition % 60)}";
                }
                else
                {
                    DurationInfoSong.Text = $"{currentPosition / 60}:{(currentPosition % 60)}";
                }
                SliderBarProcessing.Maximum = PlayerMediaService.GetCurrentSongDuration();

                SliderBarProcessing.Value = currentPosition;
                SetCurrentSongInfo();
            }
        }

        private void _timer_Tick(object? sender, EventArgs e)
        {
            if (PlayerMediaService.IsPlaying)
            {
                // Cập nhật thời gian liên tục
                UpdateDurationInfo();
            }
        }

        private bool seeking = false;
        private int lastPos = 0;
        private void SliderBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (seeking && PlayerMediaService.CurrentSong != null)
            {
                int value = Convert.ToInt32(SliderBarProcessing.Value);
                if (Math.Abs(value - lastPos) > 1)
                {
                    PlayerMediaService.SetSongPosition(value);
                    lastPos = value;
                }
            }
        }

        private void SliderBarProcessing_GotMouseCapture(object sender, MouseEventArgs e)
        {
            seeking = true;
           
        }

        private void SliderBarProcessing_LostMouseCapture(object sender, MouseEventArgs e)
        {
            seeking = false;
        }

        private void NextSongBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(PlayerMediaService.CurrentSong != null) { 
                PlayerMediaService.NextSong();
                timer.Start();

            }

        }

        private void PreSongBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (PlayerMediaService.CurrentSong != null)
            {
                PlayerMediaService.PreviousSong();
                timer.Start();


            }
        }

        private void RandomSongBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void RepeatSongBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(PlayerMediaService.RepeatMode == RepeatMode.One)
            {
                PlayerMediaService.RepeatMode = RepeatMode.Off;
                RepeatSongBtn.Foreground = Brushes.White;
            }
            else
            {
                PlayerMediaService.RepeatMode = RepeatMode.One;
                RepeatSongBtn.Foreground = Brushes.Green;
            }
        }

        private void SliderVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            int value = Convert.ToInt32(SliderVolume.Value);
            if (Math.Abs(value - lastPos) > 1)
            {
                PlayerMediaService.SetVolume(value);
                lastPos = value;
            }
        }

        private void SliderVolume_GotMouseCapture(object sender, MouseEventArgs e)
        {

        }

        private void SliderVolume_LostMouseCapture(object sender, MouseEventArgs e)
        {

        }
    }
}
