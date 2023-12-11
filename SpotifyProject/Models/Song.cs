using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace SpotifyProject.Models
{
    public class Song : MediaItem
    {
        public string Album { get; set; }
        public string Year { get; set; }
  
        public Song(string title, string artist, MediaType type, string path, string album, string year) : base(title, artist, type, path)
        {
            this.Album = album;
            this.Year = year;
        }
   
        
    }

}
