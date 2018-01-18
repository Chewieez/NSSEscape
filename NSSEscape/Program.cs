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
            EnterInstructorToCohortMenu enterInstructorToCohortMenu = new EnterInstructorToCohortMenu(db);
            ModifyCohortMenu modifyCohortMenu = new ModifyCohortMenu(db);
            EnterAlumnusMenu enterAlumnusMenu = new EnterAlumnusMenu(db);
            
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
                        enterAlumnusMenu.Show();
                        break;
                    }

                    case 4: {
                        enterInstructorToCohortMenu.Show();
                        break;
                    }

                    case 5: {
                        viewCohorts.Show();
                        break;
                    }

                    case 7: {
                        modifyCohortMenu.Show();
                        break;
                    }

                    default: 
                        break;
                }

            } while (choice != 9);

        }
    }
}
