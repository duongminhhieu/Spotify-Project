using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SpotifyProject.Services
{
    public class DatabaseConnection
    {
        private static DatabaseConnection instance;
        static string DatabaseFilePath = "Data Source=" + Environment.CurrentDirectory + "\\Database.db";
        static SQLiteConnection Connection;

        private DatabaseConnection()
        {
            Connection = new SQLiteConnection(DatabaseFilePath);
            Connection.Open();
        }

        public SQLiteConnection getConnection()
        {
            return Connection;
        }


        public static DatabaseConnection GetInstance()
        {
            if (instance == null)
            {
                instance = new DatabaseConnection();
                instance.InitializeDatabase(instance.getConnection());
            } else if(instance.getConnection().State == System.Data.ConnectionState.Closed)
            {
                instance.getConnection().Open();
            }
            return instance;
        }

        public static void CloseConnection()
        {
            if (instance != null)
            {
                instance.getConnection().Close();
            }
        }


        public void InitializeDatabase(SQLiteConnection conn)
        {
            try
            {
                SQLiteCommand command = new SQLiteCommand(conn);
                command.CommandText = "CREATE TABLE IF NOT EXISTS Playlists (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, Image TEXT, Description TEXT)";
                command.ExecuteNonQuery();
                command.CommandText = "CREATE TABLE IF NOT EXISTS MediaItems (Id INTEGER PRIMARY KEY AUTOINCREMENT, Title TEXT, Artist TEXT, Type TEXT, Path TEXT, Album TEXT, Year TEXT, PlaylistId INTEGER, FOREIGN KEY(PlaylistId) REFERENCES Playlists(Id))";
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Creating Table");
            }

        }

        

    }
}
