using System;

namespace NSSEscape
{
    public class MainMenu
    {
        public static int Show()
        {
            Console.Clear();
            Console.WriteLine ("WELCOME TO NSS ESCAPE");
            Console.WriteLine ("**************************************");
            Console.WriteLine ("1. Enter instructors");
            Console.WriteLine ("2. Enter cohorts");
            Console.WriteLine ("3. Enter alumni");
            Console.WriteLine ("4. Assign Instructor to Cohort");
            Console.WriteLine ("5. View cohort");
            Console.WriteLine ("6. Modify instructors");
            Console.WriteLine ("7. Modify cohort");
            Console.WriteLine ("8. Exit");
            

            Console.Write ("> ");
            ConsoleKeyInfo enteredKey = Console.ReadKey();
            Console.WriteLine("");
            int output = 0;
            int.TryParse(enteredKey.KeyChar.ToString(), out output);
            return output;
        }
    }
}