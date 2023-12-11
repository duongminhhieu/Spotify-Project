using Microsoft.Win32;
using SpotifyProject.Models;
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

namespace SpotifyProject.Views
{
    /// <summary>
    /// Interaction logic for PlaylistViewPage.xaml
    /// </summary>
    public partial class PlaylistViewPage : Page
    {
        private Playlist Playlist;
        public PlaylistViewPage(Playlist playlist)
        {
            InitializeComponent();
            this.Playlist = playlist;
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

      
        private void optionList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Khởi tạo OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Thiết lập các thuộc tính cho OpenFileDialog
            openFileDialog.Filter = "Music files (*.mp3, *.wav)|*.mp3;*.wav|All files (*.*)|*.*";
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
                    // Thêm logic xử lý mỗi file được chọn
                    // Ví dụ: Hiển thị tên file hoặc thêm vào danh sách các file nhạc
                    Console.WriteLine(filePath);
                }
            }
        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is ListViewItem listViewItem)
            {
                // Khởi tạo OpenFileDialog
                OpenFileDialog openFileDialog = new OpenFileDialog();

                // Thiết lập các thuộc tính cho OpenFileDialog
                openFileDialog.Filter = "Music files (*.mp3, *.wav)|*.mp3;*.wav|All files (*.*)|*.*";
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
                        // Thêm logic xử lý mỗi file được chọn
                        // Ví dụ: Hiển thị tên file hoặc thêm vào danh sách các file nhạc
                        Console.WriteLine(filePath);
                    }
                }
                // Đóng Popup sau khi xử lý
                SubMenuPopup.IsOpen = false;
            }
        }

        private void ListViewItem_PreviewMouseLeftUpdatePlaylistButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
