using SpotifyProject.Models;
using SpotifyProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SpotifyProject.ViewModels
{

    public class PlaylistPageVM
    {
        public Playlist Playlist { get; set; }
        public PlaylistService PlaylistService { get; set; }
        public MediaService MediaService { get; set; }

        public PlaylistPageVM(Playlist playlist)
        {
            Playlist = playlist;
            PlaylistService = new PlaylistService(DatabaseConnection.GetInstance().getConnection());
            MediaService = new MediaService(DatabaseConnection.GetInstance().getConnection());
        }

        public void AddSongToPlaylist(Song song)
        {
            int insertRow = MediaService.AddMediaItemSong(song, Playlist.Id);
            if(insertRow == 1)
            {
                MessageBox.Show("Song added to playlist");
            }
        }
    }
}
