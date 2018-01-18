using System;

namespace NSSEscape
{
    public class EnterInstructorsMenu
    {
        private DatabaseInterface db;
        
        public EnterInstructorsMenu(DatabaseInterface DB) {
            db = DB;
        }

        public void Show()
        {
            string instructorName;

            do {
                Console.Clear();
                Console.WriteLine("Enter Instructor (type 'quit' to Exit):");
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