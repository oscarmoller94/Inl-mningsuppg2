using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Inlämningsuppg2
{
    partial class Program
    {
        // Add members metoden returnerar en lista med alla medlemmar tillagda.
        static List<Member> bästkustenMembers = AddMembers();
        static List<Member> removedMembers = new List<Member>();

        static void Main(string[] args)
        {
            Login();
        }
        static List<Member> AddMembers()
        {
            List<Member> members = new List<Member>();
            // skapar medlemmarna och skickar med informationen till Members konstruktor.
            Member david = new Member("David", 32, 182, "BJJ", "Tacos", "Blå", "Problemlösning", "Norrtälje", "Göteborg", 1);
            Member johan = new Member("Johan", 34, 194, "Gaming", "Tacos", "Blå", "Trygg framtid", "Mariefred", "Mariefred", 2);
            Member oscar = new Member("Oscar", 26, 185, "Fotboll", "Lasagne", "Blå", "Jobb", "Stockholm", "Stockholm", 1);
            Member sanjin = new Member("Sanjin", 30, 179, "Fotboll", "Pizza", "Blå", "Jobb", "NorrKöping", "Mostar", 2);
            Member jerry = new Member("Jeremy", 19, 181, "Gaming", "Älggryta", "Teal", "Jobb", "Djurö", "Köln", 1);
            Member cecilia = new Member("Cecilia", 29, 163, "The Sims", "Risotto", "Gul", "Kreativitet", "Norrköping", "Norrköping", 1);
            Member elin = new Member("Elin", 31, 170, "Hästar", "Sushi", "Röd", "Personlig utveckling", "Knivsta", "Karlskoga", 2);
            Member ivo = new Member("Ivo", 42, 174, "Fotografering", "Scampi", "Svart", "Kreativitet", "Uppsala", "Split", 1);
            Member mostafa = new Member("Mostafa", 33, 174, "Träning", "Oxfile", "Svart", "Tycker om att koda och lösa problem", "Stockholm", "Stockholm", 1);

            members.Add(david);
            members.Add(johan);
            members.Add(oscar);
            members.Add(sanjin);
            members.Add(jerry);
            members.Add(cecilia);
            members.Add(elin);
            members.Add(ivo);
            members.Add(mostafa);
            // returnerar en lista med alla medlemmars information
            return members;
        }
        static void Login()
        {
            int errorCount = 0;
            string input;
            string correctPassword = "bästkusten";
            do
            {
                Console.Write("Skriv in lösenord: ");
                input = Console.ReadLine();
                Regex.Replace(" ", "", input);
                // ifall lösenordet är fel meddelas detta och errorCount ökas
                if (input.ToLower().Replace(" ", "") != correctPassword)
                {
                    Console.WriteLine("Fel lösenord! försök igen");
                    errorCount++;
                }
                // om errorCount når 3 så får man en ledtråd
                if (errorCount == 3)
                {
                    Console.Clear();
                    Console.WriteLine("HINT: b.stku..en");
                    errorCount = 0;
                }
                // loopen fortsätter tills rätt lösenord är inamatat. lösenordet kan skrivas med mellanrum emellan och med små/stora bokstäver tack vare .ToLower och .Replace.
            } while (input.ToLower().Replace(" ", "") != correctPassword);

            Console.Clear();
            Console.WriteLine("Välkommen till bästkusten!!");

            MainMenu();
        }
        static void MainMenu()
        {
            int choice;
            do
            {
                Console.WriteLine("\nVälj ett nummer i menyn:");
                Console.WriteLine("1. Visa alla medlemmar");
                Console.WriteLine("2. Visa detaljer om specific medlem");
                Console.WriteLine("3. Visa vad medlemmar har gemensamt");
                Console.WriteLine("4. Ta bort medlem");
                Console.WriteLine("5. Visa tidigare medlemmar");
                Console.WriteLine("6. Avsluta");

                int.TryParse(Console.ReadLine(), out choice);
                // tar in användarens val och skickar till metoden MenuAction
                MenuAction(choice);

            } while (choice != 6);
        }
        static void MenuAction(int choice)
        {
            int indexOfMember;

            switch (choice)
            {
                case 1:
                    ShowMembersOfList(bästkustenMembers);
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Välj numret bredvid den medlem som du vill visa information om:");
                    // får ut indexet på den medlemmen som användaren valt
                    indexOfMember = ChooseSpecificMember();
                    // skriver ut den medlemmen på det index som användaren har valt.
                    string memberDetails = bästkustenMembers[indexOfMember].ToString();
                    Console.WriteLine(memberDetails);
                    break;
                case 3:
                    InformationInCommonMenu();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Välj numret bredvid den medlem som du vill visa ta bort:");
                    indexOfMember = ChooseSpecificMember();
                    // här adderas det indexet som användaren vill ta bort till en annan lista för att kunna skriva ut borttagna medlemmar.
                    removedMembers.Add(bästkustenMembers[indexOfMember]);
                    Console.WriteLine($"{bästkustenMembers[indexOfMember].Name} är nu borttagen från bästkusten!");
                    bästkustenMembers.RemoveAt(indexOfMember);
                    break;
                case 5:
                    ShowMembersOfList(removedMembers);
                    break;
                case 6:
                    Exit();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Måste vara ett nummer mellan 1 och 6. Testa igen!");
                    break;
            }
        }


        static void ShowMembersOfList(List<Member> memberOfList)
        {
            // använder i denna metod en string lista som jag sedan gör en join på tillsammans med ",", därefter lägger jag till punkt så att det alltid blir en punkt efter sista namnet.
            List<string> names = new List<string>();
            foreach (var member in memberOfList)
            {
                names.Add(member.Name);
            }
            Console.Clear();
            Console.WriteLine("Nedan följer namnen på medlemmarna i bästkusten:\n");
            for (int i = 0; i < names.Count; i++)
            {
                if (i + 1 == names.Count)
                {
                    Console.Write($"{names[i]}.\n");
                }
                else if (i + 2 == names.Count)
                {
                    Console.Write($"{ names[i]} och ");
                }
                else
                {
                    Console.Write($"{names[i]},");
                }
            }
        }
        static int ChooseSpecificMember()
        {
            int returnTomainMenu = bästkustenMembers.Count + 1;
            int exitProgram = bästkustenMembers.Count + 2;

            // skapar denna variabel (även fast jag redan har en med samma värde) pga tydlighet med namn inuti loopen.
            int numberOfChoices = bästkustenMembers.Count + 2;
            int choice;
            do
            {
                // skriver ut medlemmarnas namn med ett nummer bredvid som användaren får välja. använder (i+1) för att numreringen ska starta på 1.
                for (int i = 0; i < bästkustenMembers.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}] {bästkustenMembers[i].Name}");
                }
                Console.WriteLine();

                // här lägger jag till två ytterligare alternativ under användarna
                Console.WriteLine($"[{returnTomainMenu}] Återgå till huvudmenyn");
                Console.WriteLine($"[{exitProgram}] Avsluta program");
                Console.WriteLine();
                int.TryParse(Console.ReadLine(), out choice);
                Console.WriteLine();
                // exit program kommer alltid vara det sista alternativet i menyn. Men kommer att ha olika världen beroende på hur många medlemmar som finns i listan.
                if (choice > numberOfChoices || choice <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Du måste välja ett nummer som finns i menyn. Försök igen");
                }
            } while (choice > numberOfChoices || choice <= 0);
            // ifall man väljer ett nummer som finns i menyn, så hoppar man ur loopen.

            // hanterar ifall användaren vill återvända eller avsluta.
            if (choice == returnTomainMenu)
            {
                MainMenu();
            }
            else if (choice == exitProgram)
            {
                Exit();
            }
            // (choice - 1) returneras eftersom det måste matcha med listan som är nollindexerad.
            return choice - 1;
        }
        static void InformationInCommonMenu()
        {
            int choice;
            do
            {
                Console.WriteLine("\nMedlemmar har gemensamt i följande kategorier: (Välj nummret bredvid en kategori för att få reda på vad)");
                Console.WriteLine("[1] Längd");
                Console.WriteLine("[2] Hobby");
                Console.WriteLine("[3] Favorit mat");
                Console.WriteLine("[4] Favorit färg");
                Console.WriteLine("[5] Motivation");
                Console.WriteLine("[6] Antal syskon");
                Console.WriteLine("[7] Återgå till huvudmenyn");
                Console.WriteLine("[8] Avsluta program");

                int.TryParse(Console.ReadLine(), out choice);
                // tar in användarens val och skickar till metoden InformationInCommonMenuAction metoden
                InformationInCommonMenuAction(choice);

            } while (choice != 7 || choice != 8);
        }
        static void InformationInCommonMenuAction(int choice)
        {
            // använder i denna metoden linq för att få fram vilka medlemmar det är som har samma svar på respektive kategori.
            // använder where för detta. (samt from för att filtera från specifik lista). Sedan Orderby för att sortera ut resultaten.

            switch (choice)
            {
                case 1:
                    var heightMatches = from member in bästkustenMembers
                                        where bästkustenMembers.Count(b => b.Height == member.Height) > 1
                                        orderby member.Height
                                        select member;
                    Console.Clear();
                    Console.WriteLine("Medlemmar som har samma längd: \n");
                    foreach (var matches in heightMatches)
                    {
                        Console.WriteLine($"{matches.Name} är ({matches.Height}) cm lång");
                    }
                    break;
                case 2:
                    var hobbyMatches = from member in bästkustenMembers
                                       where bästkustenMembers.Count(b => b.Hobby == member.Hobby) > 1
                                       orderby member.Hobby
                                       select member;
                    Console.Clear();
                    Console.WriteLine("Medlemmar som delar samma hobby: \n");
                    foreach (var matches in hobbyMatches)
                    {
                        Console.WriteLine($"{matches.Name} har ({matches.Hobby}) som sin hobby");
                    }
                    break;
                case 3:
                    var favoriteFoodMatches = from member in bästkustenMembers
                                              where bästkustenMembers.Count(b => b.FavoriteFood == member.FavoriteFood) > 1
                                              orderby member.FavoriteFood
                                              select member;
                    Console.Clear();
                    Console.WriteLine("Medlemmar som har samma favoritmat: \n");
                    foreach (var matches in favoriteFoodMatches)
                    {
                        Console.WriteLine($"{matches.Name} har ({matches.FavoriteFood}) som sin favoriträtt");
                    }
                    break;
                case 4:
                    var favoriteColorMatches = from member in bästkustenMembers
                                               where bästkustenMembers.Count(b => b.FavoriteColor == member.FavoriteColor) > 1
                                               orderby member.FavoriteColor
                                               select member;
                    Console.Clear();
                    Console.WriteLine("Medlemmar som har samma favoritfärg: \n");
                    foreach (var matches in favoriteColorMatches)
                    {
                        Console.WriteLine($"{matches.Name} har ({matches.FavoriteColor}) som favoritfärg");
                    }
                    break;
                case 5:
                    var motivationMatches = from member in bästkustenMembers
                                            where bästkustenMembers.Count(b => b.Motivation == member.Motivation) > 1
                                            orderby member.Motivation
                                            select member;
                    Console.Clear();
                    Console.WriteLine("Medlemmar som delar samma motivation:\n");
                    foreach (var matches in motivationMatches)
                    {
                        Console.WriteLine($"{matches.Name} har ({matches.Motivation}) som motivation");

                    }
                    break;
                case 6:
                    var siblingMatches = from member in bästkustenMembers
                                         where bästkustenMembers.Count(b => b.NumberOfSiblings == member.NumberOfSiblings) > 1
                                         orderby member.NumberOfSiblings
                                         select member;
                    Console.Clear();
                    Console.WriteLine("Medlemmar som delar samma antal syskon:\n");
                    foreach (var matches in siblingMatches)
                    {
                        Console.WriteLine($"{matches.Name} har ({matches.NumberOfSiblings}) syskon");
                    }
                    break;
                case 7:
                    Console.Clear();
                    MainMenu();
                    break;
                case 8:
                    Exit();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Måste vara ett nummer mellan 1 och 8. Testa igen");
                    return;
            }
        }

        static void Exit()
        {
            // stänger ner programmet ifall användaren skriver in y, skrivar man n skickas man till huvudmenyn.
            string input = "";
            bool quit = false;

            while (quit == false)
            {
                Console.WriteLine("Är du säker på att du vill avsluta y/n");
                input = Console.ReadLine().ToLower();

                if (input.ToLower() == "y")
                {
                    Console.Clear();
                    Console.WriteLine("Vi ses nästa gång!");
                    Environment.Exit(0);
                }
                else if (input.ToLower() == "n")
                {
                    MainMenu();
                    quit = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Tryck y/n. Försök igen!");
                }
            }
        }
    }
}

