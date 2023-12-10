using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyProject.Models
{
    public class Playlist
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public List<MediaItem> MediaItems { get; set; }

        public Playlist(string name, string image)
        {
            Name = name;
            MediaItems = new List<MediaItem>();
            Image = image;
        }

        public void AddMediaItem(MediaItem mediaItem)
        {
            MediaItems.Add(mediaItem);
        }
    }

}
