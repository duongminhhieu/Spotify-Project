﻿using SpotifyProject.Views.Dialog;
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
    /// Interaction logic for MusicPage.xaml
    /// </summary>
    public partial class MusicPage : Page
    {
        public MusicPage()
        {
            InitializeComponent();
        }

        private void NewPlaylistBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new CreatePlaylistDialog();
            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                string playlistName = dialog.PlaylistName;
                string description = dialog.Description;
                string playlistImagePath = dialog.PlaylistImagePath;
                // TODO: Xử lý logic để tạo mới playlist với tên là playlistName
            }
        }
    }
}
