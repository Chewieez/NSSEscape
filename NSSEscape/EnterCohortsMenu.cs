using System;

namespace NSSEscape
{
    public class EnterCohortsMenu
    {
        private DatabaseInterface db;

        public EnterCohortsMenu(DatabaseInterface DB) {
            db = DB;
        }

        public void Show() {
            string cohortName = "";
            string cohortServerLanguage = "";

            do {
                Console.Clear();
                // ask user for cohort name
                Console.WriteLine("Enter your cohort name and number, as 'Day5' or 'Evening5'.");
                Console.WriteLine("*******************");
                cohortName = Console.ReadLine();

                if (cohortName.ToLower() != "quit") {
                // ask user for server side language taught
                Console.WriteLine("Enter the server side language taught in this cohort.");
                Console.WriteLine("*******************");
                cohortServerLanguage = Console.ReadLine();

                }


                if (cohortName.ToLower() != "quit" && cohortName.Length > 0 && cohortServerLanguage.Length > 0) {
                    db.Insert($@"INSERT INTO Cohort (CohortId, CohortNumber, ServerSideTech)
                                VALUES (null, '{cohortName}', '{cohortServerLanguage}');");
                }

            } while (cohortName.ToLower() != "quit");
        }
    }
}