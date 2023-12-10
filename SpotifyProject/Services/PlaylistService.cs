using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyProject.Services
{
    public class PlaylistService
    {
        SQLiteConnection connection;
        public PlaylistService(SQLiteConnection conn)
        {
            connection = conn;
        }
        public int InsertPlaylist(string name, string image, string description)
        {
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "INSERT INTO Playlists (Name, Image, Description) VALUES (@name, @image, @description)";
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@image", image);
            command.Parameters.AddWithValue("@description", description);
            int result = command.ExecuteNonQuery();
            return result;
        }

        public void UpdatePlaylist(string name, string image, string description, int id)
        {
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "UPDATE Playlists SET Name = @name, Image = @image, Description = @description WHERE Id = @id";
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@image", image);
            command.Parameters.AddWithValue("@description", description);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }

        public void DeletePlaylist(int id)
        {
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "DELETE FROM Playlists WHERE Id = @id";
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }
    }
}
