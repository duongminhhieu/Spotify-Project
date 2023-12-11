using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyProject.Models
{
    public class Video : MediaItem
    {
        public Video(string title, string artist, string path) : base(title, artist, MediaType.Video, path)
        {
        }
    }

}
