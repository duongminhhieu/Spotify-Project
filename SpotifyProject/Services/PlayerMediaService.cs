
using WMPLib;

namespace SpotifyProject.Services
{

    public enum RepeatMode
    {
        Off = 0,
        One = 1,
        All = 2,
    }
    public static class PlayerMediaService
    {

        public static WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();
        public static RepeatMode RepeatMode { get; set; } = RepeatMode.Off;
        public static bool ShuffleMode { get; set; } = false;
        public static bool IsPlaying { get; set; } = false;
        public static bool IsPaused { get; set; } = false;
        public static bool IsStopped { get; set; } = true;
        public static bool IsMuted { get; set; } = false;
        public static int Volume { get; set; } = 50;
        public static int CurrentSongIndex { get; set; } = 0;
        public static int CurrentPlaylistId { get; set; } = 0;
        public static int CurrentSongId { get; set; } = 0;
        public static int CurrentSongPosition { get; set; } = 0;
        public static int CurrentSongDuration { get; set; } = 0;
        public static int CurrentSongProgress { get; set; } = 0;
        public static int CurrentSongProgressPercentage { get; set; } = 0;

        public static void PlaySong(string path)
        {
            player.URL = path;
            player.controls.play();
            IsPlaying = true;
            IsPaused = false;
            IsStopped = false;
        }
        public static void PauseSong()
        {
            player.controls.pause();
            IsPlaying = false;
            IsPaused = true;
            IsStopped = false;
        }

        public static void StopSong()
        {
            player.controls.stop();
            IsPlaying = false;
            IsPaused = false;
            IsStopped = true;
        }

        public static void MuteSong()
        {
            player.settings.mute = true;
            IsMuted = true;
        }

        public static void UnmuteSong()
        {
            player.settings.mute = false;
            IsMuted = false;
        }

        public static void SetVolume(int volume)
        {
            player.settings.volume = volume;
            Volume = volume;
        }

        public static void SetSongPosition(int position)
        {
            player.controls.currentPosition = position;
            CurrentSongPosition = position;
        }

        public static void SetSongProgress(int progress)
        {
            player.controls.currentPosition = progress;
            CurrentSongProgress = progress;
        }

        public static void SetSongProgressPercentage(int progressPercentage)
        {
            player.controls.currentPosition = (player.controls.currentItem.duration / 100) * progressPercentage;
            CurrentSongProgressPercentage = progressPercentage;
        }

        public static void SetRepeatMode(RepeatMode repeatMode)
        {
            switch (repeatMode)
            {
                case RepeatMode.Off:
                    player.settings.setMode("loop", false);
                    RepeatMode = RepeatMode.Off;
                    break;
                case RepeatMode.One:
                    player.settings.setMode("loop", true);
                    RepeatMode = RepeatMode.One;
                    break;
                case RepeatMode.All:
                    player.settings.setMode("loop", true);
                    RepeatMode = RepeatMode.All;
                    break;
            }
        }

        public static void SetShuffleMode(bool shuffleMode)
        {
            if (shuffleMode)
            {
                player.settings.setMode("shuffle", true);
                ShuffleMode = true;
            }
            else
            {
                player.settings.setMode("shuffle", false);
                ShuffleMode = false;
            }
        }

        //current song duration
        public static int GetCurrentSongDuration()
        {
            return (int)player.controls.currentItem.duration;
        }

        // contunue song
        public static void ContinueSong()
        {
            player.controls.play();
            IsPlaying = true;
            IsPaused = false;
            IsStopped = false;
        }

      

    }
}
