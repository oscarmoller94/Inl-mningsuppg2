using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
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
        private static List<Member> AddMembers()
        {
            List<Member> members = new List<Member>();

            Member david = new Member("David", 182, 32, "BJJ", "Tacos", "Blå", "Problemlösning", "Norrtälje", "Göteborg", 1);
            Member johan = new Member("Johan", 194, 34, "Gaming", "Tacos", "Blå", "Trygg framtid", "Mariefred", "Mariefred", 2);
            Member oscar = new Member("Oscar", 185, 26, "Fotboll", "Lasagne", "Blå", "Jobb", "Stockholm", "Stockholm", 1);
            Member sanjin = new Member("Sanjin", 179, 30, "Fotboll", "Pizza", "Blå", "Jobb", "NorrKöping", "Mostar", 2);
            Member jerry = new Member("Jeremy", 181, 19, "Gaming", "Älggryta", "Teal", "Jobb", "Djurö", "Köln", 1);
            Member cecilia = new Member("Cecilia", 163, 29, "The Sims", "Risotto", "Gul", "Kreativitet", "Norrköping", "Norrköping", 1);
            Member elin = new Member("Elin", 170, 31, "Hästar", "Sushi", "Röd", "Personlig utveckling", "Knivsta", "Karlskoga", 2);
            Member ivo = new Member("Ivo", 174, 42, "Fotografering", "Scampi", "Svart", "Kreativitet", "Uppsala", "Split", 1);

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
            Console.WriteLine("Welcome to bästkusten!!");

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
                Console.WriteLine("3. Show what members have in common");
                Console.WriteLine("4. Remove member from bästkusten");
                Console.WriteLine("5. Show former members");
                Console.WriteLine("6. Exit");

                int.TryParse(Console.ReadLine(), out choice);
                MenuAction(choice);

            } while (choice != 6);
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
                    InformationInCommonMenu();
                    break;
                case 4:
                    Console.WriteLine("Select the number next to the member you want to remove from group:");
                    indexOfMember = ChooseSpecificMember();
                    removedMembers.Add(bästkustenMembers[indexOfMember]);
                    bästkustenMembers.RemoveAt(indexOfMember);
                    break;
                case 5:
                    ShowMembersOfList(removedMembers);
                    break;
                case 6:
                    QuitOrContinue();
                    break;
                default:
                    Console.WriteLine("Not a valid number, try again!");
                    break;
            }
        }


        private static void ShowMembersOfList(List<Member> memberOfList)
        {
            List<string> names = new List<string>();
            foreach (var member in memberOfList)
            {
                names.Add(member.Name);
            }

            Console.WriteLine(string.Join(", ", names) + ".");
        }
        private static int ChooseSpecificMember()
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
                if (choice > bästkustenMembers.Count || choice <= 0)
                {
                    Console.WriteLine("You must choose a number that exists next to a member. Try again!");
                }
            } while (choice > bästkustenMembers.Count || choice <= 0);

            return choice - 1;
        }
        private static void InformationInCommonMenu()
        {
            int choice;
            do
            {
                Console.WriteLine("Choose which cateogry you want to see members in common: ");
                Console.WriteLine("[1] Age");
                Console.WriteLine("[2] Height");
                Console.WriteLine("[3] Hobby");
                Console.WriteLine("[4] Favorite food");
                Console.WriteLine("[5] Favorite color");
                Console.WriteLine("[6] Motivation");
                Console.WriteLine("[7] Current city");
                Console.WriteLine("[8] City of birth");
                Console.WriteLine("[9] Number of siblings");
                Console.WriteLine("[10] Return");

                int.TryParse(Console.ReadLine(), out choice);
                InformationInCommonMenuAction(choice);

            } while (choice != 10);
           
            var matches = from member in bästkustenMembers
                          where bästkustenMembers.Count(b => b.Age == member.Age) > 1
                          orderby member.Age
                          select member;
            if (matches.Count() > 1)
            {
                Console.WriteLine("Members that have the same age: ");
                foreach (var member in matches)
                {
                    Console.WriteLine($"{member.Name} {member.Age}");
                }
                Console.WriteLine();
                matches = null;
            }

            matches = from member in bästkustenMembers
                      where bästkustenMembers.Count(b => b.Height == member.Height) > 1
                      orderby member.Height
                      select member;

            if (matches.Count() > 1)
            {
                Console.WriteLine("Members that have the same height:");
                foreach (var member in matches)
                {
                    Console.WriteLine($"{member.Name} {member.Height}");
                }
                Console.WriteLine();
                matches = null;
            }

            matches = from member in bästkustenMembers
                      where bästkustenMembers.Count(b => b.Hobby == member.Hobby) > 1
                      orderby member.Hobby
                      select member;
            if (matches.Count() > 1)
            {
                Console.WriteLine("Members that share the same hobbies: ");
                foreach (var member in matches)
                {
                    Console.WriteLine($"{member.Name} {member.Hobby}");
                }
                Console.WriteLine();
                matches = null;
            }

            matches = from member in bästkustenMembers
                      where bästkustenMembers.Count(b => b.FavoriteFood == member.FavoriteFood) > 1
                      orderby member.FavoriteFood
                      select member;
            if (matches.Count() > 1)
            {
                Console.WriteLine("Members that have the same favorite food: ");
                foreach (var match in matches)
                {
                    Console.WriteLine($"{match.Name} {match.FavoriteFood}");
                }
                Console.WriteLine();
                matches = null;
            }

            matches = from member in bästkustenMembers
                      where bästkustenMembers.Count(b => b.FavoriteColor == member.FavoriteColor) > 1
                      orderby member.FavoriteColor
                      select member;
            if (matches.Count() > 1)
            {
                Console.WriteLine("Members that have the same favorite color: ");
                foreach (var match in matches)
                {
                    Console.WriteLine($"{match.Name} favorite color is {match.FavoriteColor}");
                }
                Console.WriteLine();
                matches = null;
            }

            matches = from member in bästkustenMembers
                      where bästkustenMembers.Count(b => b.Motivation == member.Motivation) > 1
                      orderby member.Motivation
                      select member;
            if (matches.Count() > 1)
            {
                Console.WriteLine("Members that have the same motivation: ");
                foreach (var match in matches)
                {
                    Console.WriteLine($"{match.Name} motivation is {match.Motivation}");
                }
                Console.WriteLine();
                matches = null;
            }
            matches = from member in bästkustenMembers
                      where bästkustenMembers.Count(b => b.CurrentCity == member.CurrentCity) > 1
                      orderby member.CurrentCity
                      select member;
            if (matches.Count() > 1)
            {
                Console.WriteLine("Members that live in the same city: ");
                foreach (var match in matches)
                {
                    Console.WriteLine($"{match.Name} current city is {match.CurrentCity}");
                }
                Console.WriteLine();
                matches = null;
            }
            matches = from member in bästkustenMembers
                      where bästkustenMembers.Count(b => b.CityOfBirth == member.CityOfBirth) > 1
                      orderby member.CityOfBirth
                      select member;
            if (matches.Count() > 1)
            {
                Console.WriteLine("Members that was born in the same city: ");
                foreach (var match in matches)
                {
                    Console.WriteLine($"{match.Name} city of birth is {match.CityOfBirth}");
                }
                Console.WriteLine();
                matches = null;
            }
            matches = from member in bästkustenMembers
                      where bästkustenMembers.Count(b => b.NumberOfSiblings == member.NumberOfSiblings) > 1
                      orderby member.NumberOfSiblings
                      select member;
            if (matches.Count() > 1)
            {
                Console.WriteLine("Members that has the same amount of siblings as another member: ");
                foreach (var match in matches)
                {
                    Console.WriteLine($"{match.Name} has {match.NumberOfSiblings}");
                }
                Console.WriteLine();
                matches = null;
            }
        }
        static void InformationInCommonMenuAction(int choice)
        {
            List<string> info = new List<string>();
            switch (choice)
            {

                case 1:
                    var matches = from member in bästkustenMembers
                                  where bästkustenMembers.Count(b => b.Age == member.Age) > 1
                                  orderby member.Age
                                  select member;
                    foreach (var item in matches)
                    {
                        info.Add(item.Name);
                        info.Add(item.Age.ToString());
                    }
                    break;
                    


                default:
                    break;
            }
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

            public Member(string name, int age, int height, string hobby, string favoriteFood, string favoriteColor, string motivation, string currentCity, string cityOfBirth, int numberOfSiblings)
            {
                this.Name = name;
                this.Age = age;
                this.Height = height;
                this.Hobby = hobby;
                this.FavoriteFood = favoriteFood;
                this.FavoriteColor = favoriteColor;
                this.Motivation = motivation;
                this.CurrentCity = currentCity;
                this.CityOfBirth = cityOfBirth;
                this.NumberOfSiblings = numberOfSiblings;

            }
            public string Describe()
            {
                return $"Namn: {Name}\nÅlder: {Age}\nLängd: {Height}\nHobby: {Hobby}\nFavoritkäk: {FavoriteFood}\nFavoritfärg: {FavoriteColor}\n" +
                    $"Motivation: {Motivation}\nHemort: {CurrentCity}\nFödelseort: {CityOfBirth}\nSyskon: {NumberOfSiblings}\n";
            }

        }
    }
}

