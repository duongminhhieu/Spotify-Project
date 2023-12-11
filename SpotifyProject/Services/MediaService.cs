using SpotifyProject.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace SpotifyProject.Services
{
    public class MediaService
    {
        SQLiteConnection connection;
        public MediaService(SQLiteConnection conn)
        {
            connection = conn;
        }

        public int AddMediaItemSong(Song song, int idPlaylist)
        {
            try {
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "INSERT INTO MediaItems (Title, Artist, Type, Path, Album, Year, PlaylistId) VALUES (@title, @artist, @type, @path, @album, @year, @idPlaylist)";
                command.Parameters.AddWithValue("@title", song.Title);
                command.Parameters.AddWithValue("@artist", song.Artist);
                command.Parameters.AddWithValue("@type", song.Type);
                command.Parameters.AddWithValue("@path", song.Path);
                command.Parameters.AddWithValue("@album", song.Album);
                command.Parameters.AddWithValue("@year", song.Year);
                command.Parameters.AddWithValue("@idPlaylist", idPlaylist);

                int result = command.ExecuteNonQuery();
                return result;
            } catch(Exception err) {
                MessageBox.Show("Error adding song to playlist");
                return -1;
            }
            
        }
    }
}
