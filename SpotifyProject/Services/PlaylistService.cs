using SpotifyProject.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SpotifyProject.Services
{
    public class PlaylistService
    {
        SQLiteConnection connection;
        private MediaService mediaService;
        public PlaylistService(SQLiteConnection conn)
        {
            connection = conn;
            mediaService = new MediaService(conn);
        }
        public int InsertPlaylist(string name, string image, string description)
        {
            try
            {
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "INSERT INTO Playlists (Name, Image, Description) VALUES (@name, @image, @description)";
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@image", image);
                command.Parameters.AddWithValue("@description", description);
                int result = command.ExecuteNonQuery();
                return result;
            }
            catch
            {
                MessageBox.Show("Error adding playlist");
                return -1;
            }
           
        }

        public void UpdatePlaylist(string name, string image, string description, int id)
        {
            try
            {
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "UPDATE Playlists SET Name = @name, Image = @image, Description = @description WHERE Id = @id";
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@image", image);
                command.Parameters.AddWithValue("@description", description);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Error updating playlist");
            }
            
        }

        public void DeletePlaylist(int id)
        {
            try
            {
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "DELETE FROM Playlists WHERE Id = @id";
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            } catch
            {
                MessageBox.Show("Error deleting playlist");
            }
            
        }

        public List<Playlist> GetAllPlaylist()
        {
            try
            {
                List<Playlist> playlists = new List<Playlist>();
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "SELECT * FROM Playlists";
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["Id"]);
                    string name = reader["Name"].ToString();
                    string image = reader["Image"].ToString();
                    string description = reader["Description"].ToString();
                    Playlist playlist = new Playlist(name, image, description);
                    playlist.Id = id;

                    // get list Media items
                    List<MediaItem> lst = new List<MediaItem>();
                    lst = mediaService.GetListMediaItemsOfPlaylist(id);

                    playlist.MediaItems = lst;
                    playlists.Add(playlist);
                }
                return playlists;
            }
            catch
            {
                MessageBox.Show("Error getting all playlists");
                return new List<Playlist>();
            }
           
        }

        public Playlist GetPlaylist(int id)
        {
            try
            {
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "SELECT * FROM Playlists WHERE Id = @id";
                command.Parameters.AddWithValue("@id", id);
                SQLiteDataReader reader = command.ExecuteReader();
                Playlist playlist = new Playlist("", "", "");
                while (reader.Read())
                {
                    string name = reader["Name"].ToString();
                    string image = reader["Image"].ToString();
                    string description = reader["Description"].ToString();
                    playlist = new Playlist(name, image, description);
                    playlist.Id = id;

                    // get list Media items
                    List<MediaItem> lst = new List<MediaItem>();
                    lst = mediaService.GetListMediaItemsOfPlaylist(id);

                    playlist.MediaItems = lst;
                }
                return playlist;
            }
            catch
            {
                MessageBox.Show("Error getting playlist");
                return new Playlist("", "", "");
            }
            
        }

    }
}
