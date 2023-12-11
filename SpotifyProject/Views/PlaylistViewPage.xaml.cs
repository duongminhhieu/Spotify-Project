using Id3;
using Microsoft.Win32;
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

                            if (tag != null)
                            {
                                // Lấy thông tin từ các khung ID3
                                string title = tag.Title == null ? "" : tag.Title;
                                string artist = tag.Artists == null ? "" : tag.Artists;
                                string album = tag.Album == null ? "" : tag.Album;
                                string year = tag.Year == null ? "" : tag.Year;
                                string genre = tag.Genre == null ? "" : tag.Genre;
                                string length = tag.Length == null ? "" : tag.Length;
                                
                                Song song = new Song(title, artist, album, year, genre, length, filePath);
                                PlaylistPageVM.AddSongToPlaylist(song);
                            }else
                            {
                                // Create Object Song
                                Song song = new Song(filePath.Substring(0, filePath.IndexOf('.')), "", "", "", "", "", filePath);
                                PlaylistPageVM.AddSongToPlaylist(song);
                            }
                        }
                          
                    }
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
    }
}
