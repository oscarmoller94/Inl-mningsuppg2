using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Inlämningsuppg2
{
    class Program
    {
        static void Main(string[] args)
        {   
            Login();
        }

        private static List<Member> AddMembers()
        {
            List<Member> members = new List<Member>();

            Member david = new Member
            {
                Name = "David",
                Height = 182,
                Age = 32,
                Hobby = "BJJ",
                FavoriteFood = "Tacos",
                FavoriteColor = "Blå",
                Motivation = "Problemlösning",
                CurrentCity = "Norrtälje",
                CityOfBirth = "Göteborg",
                NumberOfSiblings = 1
            };
            Member johan = new Member
            {
                Name = "Johan",
                Height = 194,
                Age = 34,
                Hobby = "Gaming",
                FavoriteFood = "Tacos",
                FavoriteColor = "Blå",
                Motivation = "Trygg framtid",
                CurrentCity = "Mariefred",
                CityOfBirth = "Mariefred",
                NumberOfSiblings = 2

            };
            Member oscar = new Member
            {
                Name = "Oscar",
                Height = 185,
                Age = 26,
                Hobby = "Fotboll",
                FavoriteFood = "Lasagne",
                FavoriteColor = "Blå",
                Motivation = "Jobb",
                CurrentCity = "Stockholm",
                CityOfBirth = "Stockholm",
                NumberOfSiblings = 1

            };
            Member sanjin = new Member
            {
                Name = "Sanjin",
                Height = 179,
                Age = 30,
                Hobby = "Fotboll",
                FavoriteFood = "Pizza",
                FavoriteColor = "Blå",
                Motivation = "Jobb",
                CurrentCity = "Norrköping",
                CityOfBirth = "Mostar",
                NumberOfSiblings = 2

            };
            Member jerry = new Member
            {
                Name = "Jeremy",
                Height = 181,
                Age = 19,
                Hobby = "Gaming",
                FavoriteFood = "Älggryta",
                FavoriteColor = "Teal",
                Motivation = "Jobb",
                CurrentCity = "Djurö",
                CityOfBirth = "Köln",
                NumberOfSiblings = 1

            };
            Member cecilia = new Member
            {
                Name = "Cecilia",
                Height = 163,
                Age = 29,
                Hobby = "The Sims",
                FavoriteFood = "Risotto",
                FavoriteColor = "Gul",
                Motivation = "Kreativitet",
                CurrentCity = "Norrköping",
                CityOfBirth = "Norrköping",
                NumberOfSiblings = 1

            };
            Member elin = new Member
            {
                Name = "Elin",
                Height = 170,
                Age = 31,
                Hobby = "Hästar",
                FavoriteFood = "Sushi",
                FavoriteColor = "Röd",
                Motivation = "Personlig utveckling",
                CurrentCity = "Knivsta",
                CityOfBirth = "Karlskoga",
                NumberOfSiblings = 2
            };
            Member ivo = new Member
            {
                Name = "Ivo",
                Height = 174,
                Age = 42,
                Hobby = "Fotografering",
                FavoriteFood = "Scampi",
                FavoriteColor = "Svart",
                Motivation = "Kreativitet",
                CurrentCity = "Uppsala",
                CityOfBirth = "Split",
                NumberOfSiblings = 1
            };
            members.Add(david);
            members.Add(johan);
            members.Add(oscar);
            members.Add(sanjin);
            members.Add(jerry);
            members.Add(cecilia);
            members.Add(elin);
            members.Add(ivo);

            return members;

        }
        private static void Login()
        {
            string input;
            do
            {
                Console.Write("Enter the password: ");
                input = Console.ReadLine().ToLower();

            } while (input != "bästkusten");

            Console.Clear();
            Console.WriteLine("Welcome!!");

            MainMenu();

        }
        private static void MainMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("Pick a number from the menu:");
                Console.WriteLine("1. Show all members");
                Console.WriteLine("2. Details about specific member");
                Console.WriteLine("3. Remove member");
                Console.WriteLine("4. Exit");
                int.TryParse(Console.ReadLine(), out choice);
                MenuAction(choice);
            } while (choice != 4);

            Console.WriteLine("See you next time!");
           
        }
        private static void MenuAction(int choice)
        {
            List<Member> bästkustenMembers = AddMembers();
            switch (choice)
            {
                case 1:
                    ShowAllMembers(bästkustenMembers);
                    Console.WriteLine();
                    break;
                case 2:
                    Console.WriteLine("Select the number next to the member you want to reveal details about:");
                    int userChoice = ChooseSpecificMember(bästkustenMembers);
                    bästkustenMembers[userChoice].Describe();
                    break;
                case 3:
                    Console.WriteLine("Select the number next to the member you want to remove from group:");
                    userChoice = ChooseSpecificMember(bästkustenMembers);
                    bästkustenMembers.RemoveAt(userChoice);
                    break;
                case 4:
                    break;
                default:
                    break;
            }
        }
   

        public static void ShowAllMembers(List<Member>members)
        {
            foreach (var member in members)
            {
                Console.WriteLine(member.Name);
            }
        }
        public static int ChooseSpecificMember(List<Member> members)
        {
            int counter = 1;
            for (int i = 0; i < members.Count; i++)
            {
                Console.WriteLine($"[{counter}] {members[i].Name}");
            }
            int.TryParse(Console.ReadLine(), out int choice);
            return choice;

        }
      
        public class Member
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public int Height { get; set; }
            public string Hobby { get; set; }
            public string FavoriteFood { get; set; }

            public string FavoriteColor { get; set; }
            public string Motivation { get; set; }

            public string CurrentCity { get; set; }
            public string CityOfBirth { get; set; }
            public int NumberOfSiblings { get; set; }

            public string Describe()
            {
                return $"{Name}\n{Age}\n{Height}\n{Hobby}\n{FavoriteFood}\n{FavoriteColor}\n{Motivation}\n{CurrentCity}\n{CityOfBirth}\n{NumberOfSiblings}\n";
            }

        }
    }
}
