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

        public void viewCohortDetails(string sqlStatement)
        {
            List<string> cohortInfo = new List<string>();

            db.Query(sqlStatement,
                    (SqliteDataReader reader) =>
                    {
                        while (reader.Read())
                        {
                            cohortInfo.Add(reader.GetString(0));
                        }
                    });

            int count = 0;

            foreach (string info in cohortInfo)
            {            
                count++;
                Console.WriteLine(count + " " + info);
            }
            
            Console.WriteLine("Press enter to return to Cohort options");
            Console.ReadLine();
        }
        public ViewCohortsMenu(DatabaseInterface DB)
        {
            db = DB;
        }

        public void Show()
        {
            string cohortSelection;
            ConsoleKeyInfo enteredKey;

            Cohort currentCohort = new Cohort();

                Console.WriteLine("Enter A Cohort (as Day1-Day21, Evening1-Evening5):");
                Console.WriteLine("*******************");
                Console.Write("> ");
                cohortSelection = Console.ReadLine();

            do
            {
                Console.WriteLine("Select An Option (press 'Escape' to go back to the main menu):");
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
                            string SqlStatement = $@"
                            SELECT a.Name From Alumni a
                            LEFT JOIN Cohort c ON c.CohortId = a.CohortId
                            WHERE c.CohortNumber = '{cohortSelection}'";
                            viewCohortDetails(SqlStatement);
                            break;
                        }

                    case 2:
                        {
                            // View Server Side Tech
                            string SqlStatement = $@"
                            SELECT ServerSideTech from Cohort 
                            WHERE CohortNumber = '{cohortSelection}'";
                            viewCohortDetails(SqlStatement);
                            break;
                        }

                    case 3:
                        {
                            // View Instructors
                            string SqlStatement = $@"
                            SELECT i.Name from Instructors i 
                            LEFT JOIN CohortInstructorsJoin ij ON ij.InstructorId = i.Id
                            LEFT JOIN Cohort c ON ij.CohortId = c.CohortId
                            WHERE c.CohortNumber = '{cohortSelection}'";
                            viewCohortDetails(SqlStatement);
                            break;
                        }

                    default:
                        break;
                }

            } while (enteredKey.Key != ConsoleKey.Escape);
        }
    }
}