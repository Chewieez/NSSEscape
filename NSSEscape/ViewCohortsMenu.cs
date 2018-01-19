using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace NSSEscape
{
    public class ViewCohortsMenu
    {
        private DatabaseInterface db;
        private EnterAlumnusMenu _enterAlumnusMenu = new EnterAlumnusMenu(new DatabaseInterface());
        private List<Cohort> _cohorts = new List<Cohort>();
        public ViewCohortsMenu(DatabaseInterface DB)
        {
            db = DB;
        }

        public void Show()
        {
            string cohortSelection;
            ConsoleKeyInfo enteredKey;

            Cohort currentCohort = new Cohort();

            do
            {
                Console.WriteLine("Enter A Cohort (as Day1-Day21, Evening1-Evening5):");
                Console.WriteLine("*******************");
                Console.Write("> ");
                cohortSelection = Console.ReadLine();
                db.Query($"select * from cohort where cohortNumber = '{cohortSelection}'",
                    (SqliteDataReader reader) =>
                    {
                        while (reader.Read())
                        {
                            currentCohort.cohort_id = reader.GetInt32(0);
                            currentCohort.cohort_name = reader.GetString(1);
                            currentCohort.server_tech = reader.GetString(2);
                        }
                    });

                Console.WriteLine("Select An Option:");
                Console.WriteLine("*******************");
                Console.WriteLine($"1. View Alumni for {cohortSelection}");
                Console.WriteLine($"2. View Server Side Technology for {cohortSelection}");
                Console.WriteLine($"3. View Instructors for {cohortSelection}");

                Console.Write("> ");
                enteredKey = Console.ReadKey();
                Console.WriteLine("");
                int output = 0;
                int.TryParse(enteredKey.KeyChar.ToString(), out output);

                switch (output)
                {

                    case 1:
                        {
                            // View Alumni
                            break;
                        }

                    case 2:
                        {
                            // View Server Side Tech
                            break;
                        }

                    case 3:
                        {
                            // View Instructors
                            break;
                        }

                    case 9:
                        {                            
                        MainMenu.Show();
                            break;
                        }

                    default:
                        break;
                }

            } while (enteredKey.Key != ConsoleKey.Escape);
        }
    }
}