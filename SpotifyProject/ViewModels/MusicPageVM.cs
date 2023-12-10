using SpotifyProject.Models;
using SpotifyProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyProject.ViewModels
{
    public class MusicPageVM
    {
        public PlaylistService PlaylistService { get; set; }
        public List<Playlist> Playlists { get; set; }
        public MusicPageVM()
        {
            PlaylistService = new PlaylistService(DatabaseConnection.GetInstance().getConnection());
        }

        public void LoadPlaylists()
        {
            Playlists = PlaylistService.GetAllPlaylist();
        }
    }
}
