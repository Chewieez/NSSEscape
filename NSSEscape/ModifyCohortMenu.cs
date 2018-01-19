using System;
using Microsoft.Data.Sqlite;

namespace NSSEscape
{
    public class ModifyCohortMenu
    {
        private DatabaseInterface db;

        public ModifyCohortMenu(DatabaseInterface DB) {
            db = DB;
        }

        public void Show()
        {
            string CurrentCohortName = "";
            string CurrentCohortServerLanguage = "";
            string NewCohortName = "";
            string NewCohortServerLanguage = "";

            do {
                Console.Clear();
                Console.WriteLine("Enter the current cohort name, as Day5 or Evening5. (type 'quit' to Exit)");
                Console.WriteLine("*******************");
                CurrentCohortName = Console.ReadLine();
                
                // find the record for the cohort in the db and retrieve data
                db.Query($@"
                            SELECT * FROM Account
                            WHERE CohortNumber = '{CurrentCohortName}';
                            ", (SqliteDataReader reader) =>
                        {
                            while (reader.Read ())
                            {
                                CurrentCohortName = reader.GetString(1);
                                CurrentCohortServerLanguage = reader.GetString(2);
                            }
                        });

                // give user the current cohort name and ask them for the new modified name
                Console.WriteLine($"Current cohort name: {CurrentCohortName}");
                Console.WriteLine("Enter the new cohort name, as Day5 or Evening5");
                Console.WriteLine("*******************");
                NewCohortName = Console.ReadLine();

                // give user the current server language and ask them for the new modified language
                if (CurrentCohortName.ToLower() != "quit") {
                    
                    Console.WriteLine($"Current cohort server language: {CurrentCohortServerLanguage}");
                    Console.WriteLine("Enter the new server side language taught in this cohort.");
                    Console.WriteLine("*******************");
                    NewCohortServerLanguage = Console.ReadLine();
                }

                // update the cohort entry in the db
                if (CurrentCohortName.ToLower() != "quit" && CurrentCohortName.Length > 0) {
                    db.Update($@"UPDATE INTO Instructors (CohortName, ServerSideTech)
                                VALUES ('{CurrentCohortName}', '{CurrentCohortServerLanguage}');");
                }


            } while (CurrentCohortName.ToLower() != "quit");
        }
    }
}