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
            Console.WriteLine ("1. Enter cohort");
            Console.WriteLine ("2. Enter instructors");
            Console.WriteLine ("3. Enter alumni");
            Console.WriteLine ("4. View cohort alumni");
            Console.WriteLine ("5. View cohort technology");
            Console.WriteLine ("6. View cohort instructors");
            Console.WriteLine ("7. Exit");
            

            Console.Write ("> ");
            ConsoleKeyInfo enteredKey = Console.ReadKey();
            Console.WriteLine("");
            int output = 0;
            int.TryParse(enteredKey.KeyChar.ToString(), out output);
            return output;
        }
    }
}