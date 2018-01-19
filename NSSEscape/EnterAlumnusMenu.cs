using System;
using Microsoft.Data.Sqlite;

namespace NSSEscape
{
    public class EnterAlumnusMenu
    {
        private DatabaseInterface db;

        public EnterAlumnusMenu(DatabaseInterface DB)
        {
            db = DB;
        }

        public void Show()
        {
            string AlumnusName = "";
            string Cohort;
            int CohortId = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("Enter Cohort Name (type 'quit' to Exit):");
                Console.WriteLine("*******************");
                Cohort = Console.ReadLine();

                if (Cohort.ToLower() != "quit" && Cohort.Length > 0)
                {
                    Console.WriteLine("Enter Full Alumnus Name (type 'quit' to Exit):");
                    Console.WriteLine("*******************");
                    AlumnusName = Console.ReadLine();
                    db.Query(
                            $@"select CohortId
                            From Cohort
                            Where CohortNumber = '{Cohort}';",
                            (SqliteDataReader reader) =>
                            {
                                while (reader.Read ()) {
                                    CohortId = reader.GetInt32(0);
                                }
                            }
                    );

                }

                // if user types quit in either prompt, make both variabled equal "quit" to exit out of the menu.
                if (Cohort.ToLower() == "quit") {
                    AlumnusName = "quit";
                } else if (AlumnusName.ToLower() == "quit") {
                    Cohort = "quit";
                };


                if ((Cohort.ToLower() != "quit"  && Cohort.Length > 0) && (AlumnusName.ToLower() != "quit" && AlumnusName.Length > 0))
                {
                    db.Insert($@"INSERT INTO Alumni 
                                (CohortID, Name, Id)
                                VALUES ({CohortId}, '{AlumnusName}', null);");
                }




            } while (Cohort.ToLower() != "quit" && AlumnusName.ToLower() != "quit");

        }

    }
}