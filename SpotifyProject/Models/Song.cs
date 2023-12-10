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
        public Song(string title, string artist, MediaType type, string path) : base(title, artist, type, path)
        {
        }
    }

}
