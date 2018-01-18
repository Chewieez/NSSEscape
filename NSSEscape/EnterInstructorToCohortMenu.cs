using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace NSSEscape
{
    public class EnterInstructorToCohortMenu
    {
        private DatabaseInterface db;

        public EnterInstructorToCohortMenu(DatabaseInterface DB)
        {
            db = DB;
        }

        public void Show() {
            
            string cohort;

            do {
            
                Console.WriteLine("Which Cohort?");
                Console.WriteLine("************************");
                cohort = Console.ReadLine();

                int cohortId = 0;
                db.Query($@"SELECT CohortId FROM Cohort WHERE CohortNumber='{cohort}';",
                    (SqliteDataReader reader) => 
                    {
                        while (reader.Read ())
                        {
                            cohortId = reader.GetInt32(0);
                        }
                    }
                );

                if (cohort.ToLower() != "quit") {
                    GetInstructor();
                }


            } while (cohort.ToLower() != "quit");


           

        }

        public void GetInstructor() {
             // Get instructors

            int output;

            List<Instructor> selectedInstructors = new List<Instructor>();
            List<Instructor> instructors = new List<Instructor>();

            do {
                Console.Clear();
                Console.WriteLine("Select instructors: ");
                instructors.Clear();
                db.Query($@"SELECT Name, Id FROM Instructors;",
                (SqliteDataReader reader) => 
                    {
                        while (reader.Read ())
                        {
                            instructors.Add(
                                new Instructor(){
                                    Name = reader.GetString(0),
                                    Id = reader.GetInt32(1)
                                }
                            );
                        }
                    }
                ); // end db.query


                // print out each instructor with an option
                int c = 0;
                foreach (Instructor inst in instructors) {
                    c++;
                    Console.WriteLine($"{c}. {inst.Name}");
                }
                Console.WriteLine("99. Exit");

                // do while they enter numbers
                output = 0;
                Console.Write("> ");
                string enteredValue = Console.ReadLine();
                int.TryParse(enteredValue, out output);
                
                if (output > 0 && output < 99) {
                    selectedInstructors.Add(instructors[output-1]);
                    // add instructor
                } else if (output == 99) {
                    return;
                }
                Console.WriteLine(selectedInstructors.Count());
                Console.ReadLine();

            } while (output != 99);
           
           
        }
    }
}