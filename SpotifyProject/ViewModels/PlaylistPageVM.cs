using SpotifyProject.Models;
using SpotifyProject.Services;
using WMPLib;

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
          
        }

        public void LoadPlaylist()
        {
            Playlist = PlaylistService.GetPlaylist(Playlist.Id);
        }

        public void PlaySong(Song selectedSong)
        {
            WindowsMediaPlayer wmp = new WindowsMediaPlayer();
            IWMPMedia media = wmp.newMedia(selectedSong.Path);

            wmp.currentPlaylist.appendItem(media);
            wmp.controls.play();
        }
        
       
    }
}
