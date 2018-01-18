using System;

namespace NSSEscape
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseInterface db = new DatabaseInterface();
            
            // Menu options
            EnterInstructorsMenu enterInstructorsMenu = new EnterInstructorsMenu(db);
            EnterCohortsMenu enterCohortsMenu = new EnterCohortsMenu(db);
            ViewCohortsMenu viewCohorts = new ViewCohortsMenu(db);

            int choice;

            do
            {
                choice = MainMenu.Show();
                
                switch (choice) {

                    // Enter instructors
                    case 1: {
                        enterInstructorsMenu.Show();
                        break;
                    }

                    // Enter cohorts
                    case 2: {
                        enterCohortsMenu.Show();
                        break;
                    }

                    case 3: {
                        viewCohorts.Show();
                        break;
                    }

                    

                    default: 
                        break;
                }

            } while (choice != 9);

        }
    }
}
