using System;
using Microsoft.Data.Sqlite;

namespace NSSEscape
{
    public class ViewTechnologyMenu
    {
        private string _connectionString;
        private SqliteConnection _connection;

        public ViewTechnologyMenu()
        {
            // Replace {you} with the correct value
            try {
                _connectionString = $"Data Source=NSSEscape.db";
                _connection = new SqliteConnection(_connectionString);
                Console.Write("Connected...");

            } catch (Exception err) {
                Console.WriteLine("ERROR: Not connected to db " + err.Data);
                Console.ReadLine();
            }
        }

        public void Query(string command, Action<SqliteDataReader> handler)
        {
            using (_connection)
            {
                _connection.Open ();
                SqliteCommand dbcmd = _connection.CreateCommand ();
                dbcmd.CommandText = command;

                using (SqliteDataReader dataReader = dbcmd.ExecuteReader())
                {
                    handler (dataReader);
                }
            }
        }

        public void Update(string command)
        {
            using (_connection)
            {
                _connection.Open ();
                SqliteCommand dbcmd = _connection.CreateCommand ();
                dbcmd.CommandText = command;
                dbcmd.ExecuteNonQuery ();
                dbcmd.Dispose ();
            }
        }

        public int Insert(string command)
        {
            int insertedItemId = 0;

            using (_connection)
            {
                _connection.Open ();
                SqliteCommand dbcmd = _connection.CreateCommand ();
                dbcmd.CommandText = command;

                dbcmd.ExecuteNonQuery ();

                this.Query("select last_insert_rowid()",
                    (SqliteDataReader reader) => {
                        while (reader.Read ())
                        {
                            insertedItemId = reader.GetInt32(0);
                        }
                    }
                );

                dbcmd.Dispose ();
            }
            
            return insertedItemId;
        }
    }
}