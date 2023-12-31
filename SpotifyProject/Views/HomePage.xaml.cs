﻿using SpotifyProject.Models;
using SpotifyProject.Services;
using SpotifyProject.ViewModels;
using SpotifyProject.Views.Dialog;
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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        private HomePageVM homePageVM;
        public HomePage()
        {
            InitializeComponent();
            homePageVM = new HomePageVM();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            homePageVM.LoadPlaylists();
            this.DataContext = homePageVM;
            playlistSong.ItemsSource = homePageVM.PlaylistSong;
            playlistVideo.ItemsSource = homePageVM.PlaylistVideo;
            recentsList.ItemsSource = homePageVM.RecentViews;
        }

        private void panelChoosePlaylistSong_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Playlist? selectedPlaylist = ((FrameworkElement)sender).DataContext as Playlist;

            if (selectedPlaylist != null)
            {
                NavigationService.Navigate(new PlaylistViewPage(selectedPlaylist));
            }
        }

        private void panelChoosePlaylistVideo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Playlist? selectedPlaylist = ((FrameworkElement)sender).DataContext as Playlist;

            if (selectedPlaylist != null)
            {
                NavigationService.Navigate(new PlaylistViewPage(selectedPlaylist));
            }
        }

        private void panelChooseRecent_MouseDown(object sender, MouseButtonEventArgs e)
        {

            // select song and play
            RecentView? selected = ((FrameworkElement)sender).DataContext as RecentView;

            if (selected != null)
            {
                PlayerMedia.CurrentPlaylist = homePageVM.PlaylistService.GetPlaylist(selected.PlaylistId);
                if (PlayerMedia.CurrentPlaylist.Type == PlaylistType.Song)
                {
                    var songIndex = 0;
                    Song CurrentSong = null;
                    foreach (var song in PlayerMedia.CurrentPlaylist.MediaItems)
                    {
                        if (song.Id == selected.MediaItemId)
                        {
                            CurrentSong = (Song?)song;
                            break;
                        }
                        songIndex++;
                    }

                    if (CurrentSong != null)
                    {
                        PlayerMedia.CurrentSong = CurrentSong;
                        PlayerMedia.CurrentSongIndex = songIndex;
                        PlayerMedia.PlaySong(CurrentSong.Path);
                    }
                    else
                    {
                        // reload recents
                        homePageVM.LoadRecents();
                        recentsList.ItemsSource = homePageVM.RecentViews;
                        MessageBox.Show("File not found!");

                    }


                }
                else if (PlayerMedia.CurrentPlaylist.Type == PlaylistType.Video)
                {
                    var videoIndex = 0;
                    Video CurrentVideo = null;
                    foreach (var video in PlayerMedia.CurrentPlaylist.MediaItems)
                    {
                        if (video.Id == selected.MediaItemId)
                        {
                            CurrentVideo = (Video?)video;
                            break;
                        }
                        videoIndex++;
                    }

                    if (CurrentVideo != null)
                    {
                        PlayerMedia.CurrentVideo = CurrentVideo;
                        PlayerMedia.PauseSong();
                        var dialog = new VideoViewDialog();
                        bool? result = dialog.ShowDialog();
                    }
                    else
                    {
                        // reload recents
                        homePageVM.LoadRecents();
                        recentsList.ItemsSource = homePageVM.RecentViews;
                        MessageBox.Show("File not found!");

                    }
                }

            }

        }
    }
}
