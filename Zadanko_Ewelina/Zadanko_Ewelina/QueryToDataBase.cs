using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Zadanko_Ewelina
{
    public class QueryToDataBase
    {
        public static SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqliteConn;
            sqliteConn = 
                new SQLiteConnection
                (@"Data Source = new_db.db; Version = 3; New = True; Compress = True");
            try
            {
                sqliteConn.Open();
            }
            catch
            {
            }
            return sqliteConn;
        }

        public static void CreateTable(SQLiteConnection conn)
        {
            SQLiteCommand sqliteCommand;
            sqliteCommand = conn.CreateCommand();
            sqliteCommand.CommandText = 
                "CREATE TABLE IF NOT EXISTS Personel_new(Id INTEGER NOT NULL UNIQUE, FirstName VARCHAR(50),LastName VARCHAR(50),PRIMARY KEY(Id AUTOINCREMENT));";
            sqliteCommand.ExecuteNonQuery();
            conn.Close();
        }

        public static void UpdateTable(SQLiteConnection conn, string Command)
        {
            SQLiteCommand sqliteCommand;
            sqliteCommand = conn.CreateCommand();
            sqliteCommand.CommandText = Command;
            sqliteCommand.ExecuteNonQuery();
        }

        public static void InsertData(SQLiteConnection conn, string Command)
        {
            SQLiteCommand sqliteCommand;
            sqliteCommand = conn.CreateCommand();
            sqliteCommand.CommandText = Command;
            sqliteCommand.ExecuteNonQuery();
            Zadanko_Ewelina.Model.Users.Add(new Model() 
            { 
                Id = GenerateId(conn), FirstName = Model.FirstName2, LastName = Model.LastName2 
            });
            conn.Close();
        }

        public static void ReadData(SQLiteConnection conn, string Command)
        {
            SQLiteDataReader sqliteReader;
            SQLiteCommand sqliteCommand;
            sqliteCommand = conn.CreateCommand();
            //string query = "SELECT * FROM Personel_new;"; niepotrzebne powielenie zmiennej
            sqliteCommand.CommandText = "SELECT * FROM Personel_new;";
            sqliteReader = sqliteCommand.ExecuteReader();
            while (sqliteReader.Read())
            {
                var id = sqliteReader.GetInt32(0);
                string firstname = sqliteReader.GetString(1);
                string lastname = sqliteReader.GetString(2);
                Console.WriteLine(firstname + " " + lastname);
                Zadanko_Ewelina.Model.Users.Add(new Model() { Id = id, FirstName = firstname, LastName = lastname });
            }
            conn.Close();
        }
        public static int GenerateId(SQLiteConnection conn)
        {
            SQLiteDataReader sqliteReader;
            SQLiteCommand sqliteCommand;
            var id = 0;
            sqliteCommand = conn.CreateCommand();
            sqliteCommand.CommandText = "SELECT * FROM Personel_new WHERE Id = (SELECT MAX(Id) FROM Personel_new );";
            sqliteReader = sqliteCommand.ExecuteReader();
            while (sqliteReader.Read())
            {
                id = sqliteReader.GetInt32(0);
            }
            return id;
        }
    }
}
