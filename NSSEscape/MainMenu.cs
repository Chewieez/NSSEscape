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
            Console.WriteLine ("3. View cohort");
            //Console.WriteLine ("4. Modify instructors");
            //Console.WriteLine ("5. Modiify cohort");
            Console.WriteLine ("9. Exit");
            

            Console.Write ("> ");
            ConsoleKeyInfo enteredKey = Console.ReadKey();
            Console.WriteLine("");
            int output = 0;
            int.TryParse(enteredKey.KeyChar.ToString(), out output);
            return output;
        }
    }
}