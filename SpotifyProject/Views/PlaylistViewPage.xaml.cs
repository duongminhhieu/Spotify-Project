using Id3;
using Microsoft.Win32;
using SpotifyProject.Helper;
using SpotifyProject.Models;
using SpotifyProject.Services;
using SpotifyProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace SpotifyProject.Views
{
    /// <summary>
    /// Interaction logic for PlaylistViewPage.xaml
    /// </summary>
    public partial class PlaylistViewPage : Page
    {
       private PlaylistPageVM PlaylistPageVM { get; set; }
        public PlaylistViewPage(Playlist playlist)
        {
            InitializeComponent();
            this.PlaylistPageVM= new PlaylistPageVM(playlist);
            this.DataContext = playlist;
        }
        public event EventHandler<bool> PlayPauseStateChanged;

        private void OnPlayPauseStateChanged(bool isPlaying)
        {
            PlayPauseStateChanged?.Invoke(this, isPlaying);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<Song> lst = MediaHelper.castMediaItemsToSongs(PlaylistPageVM.Playlist.MediaItems);
            listItemsMedia.ItemsSource = lst;

            // Đăng ký sự kiện từ MainWindow
            if (Window.GetWindow(this) is MainWindow mainWindow)
            {
                PlayPauseStateChanged += (s, isPlaying) => mainWindow.OnPlayPauseStateChanged(s, isPlaying);
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            // Get the NavigationService of the Frame
            NavigationService navigationService = NavigationService.GetNavigationService(this);

            // Check if it's possible to go back
            if (navigationService.CanGoBack)
            {
                // Go back to the previous page
                navigationService.GoBack();
            }
        }

        private void PlayMusicBtn_Click(object sender, RoutedEventArgs e)
        {

            if(PlaylistPageVM.Playlist.MediaItems.Count == 0)
            {
                MessageBox.Show("Playlist is empty!");
                return;
            }

            PlayerMedia.CurrentPlaylist = PlaylistPageVM.Playlist;
            PlayerMedia.CurrentSong = (Song)PlaylistPageVM.Playlist.MediaItems[0];
            PlayerMedia.CurrentSongIndex = 0;
            PlayerMedia.PlaySong(PlaylistPageVM.Playlist.MediaItems[0].Path);

            OnPlayPauseStateChanged(PlayerMedia.IsPlaying);
        }
        private void OptionBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SubMenuPopup.IsOpen = true;
        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is ListViewItem listViewItem)
            {
                // Khởi tạo OpenFileDialog
                OpenFileDialog openFileDialog = new OpenFileDialog();

                // Thiết lập các thuộc tính cho OpenFileDialog
                openFileDialog.Filter = "Music files (*.mp3)|*.mp3|All files (*.*)|*.*";
                openFileDialog.Title = "Select Music Files";
                openFileDialog.Multiselect = true; // Cho phép người dùng chọn nhiều file

                // Mở hộp thoại chọn file
                bool? result = openFileDialog.ShowDialog();

                // Xử lý kết quả chọn file
                if (result == true)
                {
                    // Lấy danh sách các đường dẫn của các file được chọn
                    string[] selectedFiles = openFileDialog.FileNames;

                    // Xử lý logic với danh sách các đường dẫn file ở đây
                    foreach (string filePath in selectedFiles)
                    {
                        // Đọc thông tin ID3 của file MP3
                        using (var mp3 = new Mp3(filePath))
                        {
                            Id3Tag tag = mp3.GetTag(Id3TagFamily.Version2X);
                            var duration = mp3.Audio.Duration;

                            if (tag != null)
                            {
                                // Lấy thông tin từ các khung ID3
                                string title = tag.Title;
                                string artist = tag.Artists;
                                string album = tag.Album;
                                string year = tag.Year;
                                string genre = tag.Genre;
                                string length = $"{duration.Minutes}:{duration.Seconds}";
                                
                                Song song = new Song( title ?? "Unknown", (artist == "" ? "Unknown" : artist), album ?? "Unknown", year ?? "Unknown", genre ?? "Unknown", length ?? "Unknown", filePath);
                                PlaylistPageVM.AddSongToPlaylist(song);
                            }else
                            {
                                // Create Object Song
                                Song song = new Song(filePath.Substring(0, filePath.IndexOf('.')), "Unknown", "Unknown", "Unknown", "Unknown", $"{duration.Minutes}:{duration.Seconds}", filePath);
                                PlaylistPageVM.AddSongToPlaylist(song);
                            }
                        }
                          
                    }

                    // reload playlist
                    PlaylistPageVM.LoadPlaylist();
                    List<Song> lst = MediaHelper.castMediaItemsToSongs(PlaylistPageVM.Playlist.MediaItems);
                    listItemsMedia.ItemsSource = lst;
                    MessageBox.Show("Add song successfully!");
                }

                // Đóng Popup sau khi xử lý
                SubMenuPopup.IsOpen = false;
            }
        }

        private void ListViewItem_PreviewMouseLeftUpdatePlaylistButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void ListViewItem_PreviewMouseRemoveLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // select song and play
            Song? selectedSong = ((FrameworkElement)sender).DataContext as Song;

            if (selectedSong != null)
            {
                PlayerMedia.CurrentPlaylist = PlaylistPageVM.Playlist;
                PlayerMedia.CurrentSong = selectedSong;
                PlayerMedia.CurrentSongIndex = PlaylistPageVM.Playlist.MediaItems.IndexOf(selectedSong);
                PlayerMedia.PlaySong(selectedSong.Path);
                OnPlayPauseStateChanged(PlayerMedia.IsPlaying);
                
            }
        }

    }
}
