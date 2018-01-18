using System;
using Microsoft.Data.Sqlite;

namespace NSSEscape
{
    public class EnterAlumnusMenu
    {
        private DatabaseInterface db;

        public void EnterAlumnus(DatabaseInterface DB)
        {
            db = DB;
        }

        public void Show()
        {
            string AlumnusName;
            string Cohort;
            int CohortId = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("Enter Cohort (type 'quit' to Exit):");
                Console.WriteLine("*******************");
                Cohort = Console.ReadLine();
                Console.WriteLine("Enter Full Alumnus Name (type 'quit' to Exit):");
                Console.WriteLine("*******************");
                AlumnusName = Console.ReadLine();
                db.Query(
                        $@"select CohortId
                        From Cohort
                        Where CohortNumber = '{Cohort}';",
                        (SqliteDataReader reader) =>
                        {
                            CohortId = reader.GetInt32(0);
                        }
                );


                if (AlumnusName.ToLower() != "quit" && AlumnusName.Length > 0)
                {
                    db.Insert($@"INSERT INTO Alumni (CohortID, Name, Id)
                                VALUES ('{CohortId}', '{AlumnusName}', null);");
                }

            } while (AlumnusName.ToLower() != "quit");

        }

    }
}