using System;

namespace Inlämningsuppg2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = " ";
            int choice = 0;
            bool keepPlaying = true;
            do
            {
                Console.WriteLine("Enter the group name:");
                input = Console.ReadLine().ToLower();

            } while (input != "bästkusten");
            Console.WriteLine("Welcome!!");

            do
            {
                Console.WriteLine("Pick a number from the menu:");
                Console.WriteLine("1. Show all members");
                Console.WriteLine("2. Details about specific member");
                Console.WriteLine("3. Remove member");
                Console.WriteLine("4. Exit");
                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    default:
                        break;
                }

            } while (keepPlaying == true);
        }
    }
}
