using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Inlämningsuppg2
{
    class Program
    {
        static List<Member> bästkustenMembers = AddMembers();
        static List<Member> removedMembers = new List<Member>();
        static void Main(string[] args)
        {
            
            Login();
        }

        private static void Login()
        {
            string input;
            string correctPassword = "bästkusten";
            do
            {
                Console.Write("Enter the password: ");
                input = Console.ReadLine();

                if (input.ToLower() != correctPassword)
                {
                    Console.WriteLine("Wrong password. Try again!");
                }

            } while (input.ToLower() != correctPassword);

            Console.Clear();
            Console.WriteLine("Welcome!!");

            MainMenu();

        }
        private static void MainMenu()
        {
            int choice;
            do
            {
                Console.WriteLine("Pick a number from the menu:");
                Console.WriteLine("1. Show all members");
                Console.WriteLine("2. Details about specific member");
                Console.WriteLine("3. Remove member");
                Console.WriteLine("4. Show removed members");
                Console.WriteLine("5. Exit");

                int.TryParse(Console.ReadLine(), out choice);
                MenuAction(choice);
          
            } while (choice != 5);
        }
        private static void QuitOrContinue()
        {
            string input = "";
            bool quit = false;

            while (quit == false)
            {
                Console.WriteLine("Are you sure you want to quit? y/n");
                input = Console.ReadLine();

                if (input.ToLower() == "y")
                {
                    Console.Clear();
                    Console.WriteLine("See you next time!");
                    quit = true;
                }
                else if (input.ToLower() == "n")
                {
                    MainMenu();
                    quit = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Not valid input. Press y/n");
                }
            }
                

            
      
        } 
        private static void MenuAction(int choice)
        {
            int indexOfMember;
           
            switch (choice)
            {
                case 1:
                    ShowMembersOfList(bästkustenMembers);
                    break;
                case 2:
                    Console.WriteLine("Select the number next to the member you want to reveal details about:");
                    indexOfMember = ChooseSpecificMember();
                    string memberDetails = bästkustenMembers[indexOfMember].Describe();
                    Console.WriteLine(memberDetails);
                    break;
                case 3:
                    Console.WriteLine("Select the number next to the member you want to remove from group:");
                    indexOfMember = ChooseSpecificMember();
                    removedMembers.Add(bästkustenMembers[indexOfMember]);
                    bästkustenMembers.RemoveAt(indexOfMember);
                    break;
                case 4:
                    ShowMembersOfList(removedMembers);
                    break;
                case 5:
                    QuitOrContinue();
                    break;
                default:
                    Console.WriteLine("Not a valid number, try again!");
                    break;
            }
        }
   

        public static void ShowMembersOfList(List<Member>memberOfList)
        {
            foreach (var member in memberOfList)
            {
                Console.Write(member.Name + ",");
            }
            Console.WriteLine();
        }
        public static int ChooseSpecificMember()
        {
            int choice;
            do
            {
                int counter = 1;
                for (int i = 0; i < bästkustenMembers.Count; i++)
                {
                    Console.WriteLine($"[{counter}] {bästkustenMembers[i].Name}");
                    counter++;
                }
                Console.WriteLine();
                int.TryParse(Console.ReadLine(), out choice);
                Console.WriteLine();
                if(choice > bästkustenMembers.Count || choice <= 0)
                {
                    Console.WriteLine("You must choose a number that exists next to a member. Try again!");
                }
            } while (choice > bästkustenMembers.Count || choice <= 0);
           
            return choice - 1;
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
                return $"Namn: {Name}\nÅlder: {Age}\nLängd: {Height}\nHobby: {Hobby}\nFavoritkäk: {FavoriteFood}\nFavoritfärg: {FavoriteColor}\n" +
                    $"Motivation: {Motivation}\nHemort: {CurrentCity}\nFödelseort: {CityOfBirth}\nSyskon: {NumberOfSiblings}\n";
            }

        }
    }
}
