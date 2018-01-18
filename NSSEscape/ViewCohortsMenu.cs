using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace NSSEscape
{
    public class ViewCohortsMenu
    {
        private DatabaseInterface db;
        private List<Cohort> _cohorts = new List<Cohort>();
        public ViewCohortsMenu(DatabaseInterface DB)
        {
            db = DB;
        }

        public void Show()
        {
            db.Query("select * from cohort",
                (SqliteDataReader reader) =>
                {
                    _cohorts.Clear();
                    while (reader.Read())
                    {
                        _cohorts.Add(new Cohort()
                        {
                            cohort_id = reader.GetInt32(0),
                            cohort_number = reader.GetInt32(1),
                            server_tech = reader.ToString()
                        });
                    }
                }
            );
            
            do {
                Console.Clear();
                Console.WriteLine("Select Cohort (type 'quit' to Exit):");
                Console.WriteLine("*******************");
                instructorName = Console.ReadLine();
                
                if (instructorName.ToLower() != "quit" && instructorName.Length > 0) {
                    db.Insert($@"INSERT INTO Instructors (Name, Id)
                                VALUES ('{instructorName}', null);");
                }

            } while (instructorName.ToLower() != "quit");
        }
    }
}