using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyProject.Models
{
    public class MediaItem : INotifyPropertyChanged
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Path { get; set; }

        public MediaType Type { get; set; }

        public MediaItem(string title, string artist, MediaType type, string path)
        {
            Title = title;
            Artist = artist;
            Type = type;
            Path = path;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }

    public enum MediaType
    {
        Song,
        Video
    }

}
