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
            string cohortSelection;
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

                    Console.WriteLine(currentCohort.cohort_name + " " + currentCohort.server_tech);

                // if (cohortSelection =) {
                //     db.Insert($@"INSERT INTO Instructors (Name, Id)
                //                 VALUES ('{}', null);");
                // }

            } while (cohortSelection != "quit");
        }
    }
}