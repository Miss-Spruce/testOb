using System;
using System.Collections.Generic;
using System.Linq;

namespace testOb
{
    class Program
    {
        static void Main()
        {
            var FamilyList = SetUpFamilyList();

            Console.WriteLine("hjelp => viser en hjelpetekst som forklarer alle kommandoene");

            while (true)
            {
                Console.Write("Input: ");
                var input = Console.ReadLine();

                if (input.Length == 0)
                {
                    continue;
                }

                if (input == "hjelp")
                {
                    Commands();
                }
                else if (input == "liste")
                {
                    foreach (var person in FamilyList)
                    {
                        person.InfoList();
                    }
                }
                else if (input.Substring(0, 4) == "vis ")
                {
                    var indexStr = input.Substring(4);
                    if (indexStr.Length == 0 || !indexStr.All(char.IsDigit))
                    {
                        Console.WriteLine($"  ID må være et tall mellom 1 og {FamilyList.Count}.");
                        continue;
                    }
                    var index = int.Parse(indexStr) - 1;
                    if (index >= FamilyList.Count || index < 0)
                    {
                        Console.WriteLine($"  ID må være et tall mellom 1 og {FamilyList.Count}.");
                        continue;
                    }

                    FamilyList[index].InfoPerson(FamilyList);
                }
                else
                {
                    Console.WriteLine("  Ikke godkjent input. Skriv \"hjelp\" for å se alternativer.");
                }
            }
        }

        private static List<Person> SetUpFamilyList()
        {
            var Lena = new Person { Id = 1, FirstName = "Lena Therese", LastName = "Gran", BirthYear = 1992 };
            var Ole = new Person { Id = 2, FirstName = "Ole Johnny", LastName ="Sogn", BirthYear = 1986 };
            var Malin = new Person { Id = 3, FirstName = "Malin", LastName = "Gran", BirthYear = 1990 };
            var Veronika = new Person { Id = 4, FirstName = "Veronika", LastName = "Gran", BirthYear = 1998 };
            var Ronja = new Person { Id = 5, FirstName = "Ronja", LastName = "Gran", BirthYear = 2000 };
            var Bjørnar = new Person { Id = 6, FirstName = "Bjørnar", LastName = "Gran", BirthYear = 1966 };
            var Jeanette = new Person { Id = 7, FirstName = "Jeanette", LastName = "Sogn", BirthYear = 1967 };
            var Brit = new Person { Id = 8, FirstName = "Brit Venke", MaidenName ="Johansen",LastName = "Gran", BirthYear = 1970 };
            var Trygve = new Person { Id = 9, FirstName = "Trygve", BirthYear = 1942, DeathYear = 2010, };
            var Grethe = new Person { Id = 10, FirstName = "Grethe", MaidenName = "Hansen", BirthYear = 1952 };
            var Jan = new Person { Id = 11, FirstName = "Jan-Egil", LastName = "Sogn", BirthYear = 1944 };
            var Rita = new Person { Id = 12, FirstName = "Rita", MaidenName = "Berg", LastName = "Sogn", BirthYear = 1947 };
            var Hella = new Person { Id = 13, FirstName = "Hella", LastName = "Gran", MaidenName = "Horn", BirthYear = 1915, DeathYear = 1998 };
            var Sverre = new Person { Id = 14, FirstName = "Sverre", LastName = "Gran", BirthYear = 1910, DeathYear = 1992 };
            var Ruth = new Person { Id = 15, FirstName = "Ruth Amalie", LastName = "Hansen", MaidenName ="Åtlo", BirthYear = 1920, DeathYear = 2010 };
            var Gustav = new Person { Id = 16, FirstName = "Gustav", LastName = "Vang Hansen", BirthYear = 1914, DeathYear = 1978 };
            var Laila = new Person { Id = 17, FirstName = "Laila", LastName = "Berg", BirthYear = 1915};
            var Bjarne = new Person { Id = 18, FirstName = "Bjarne", LastName = "Berg", BirthYear = 1912};
            var Astrid = new Person { Id = 19, FirstName = "Astrid", LastName = "Sogn", BirthYear = 1910};
            var Adolf = new Person { Id = 20, FirstName = "Adolf", LastName = "Sogn", BirthYear = 1908};
            var Amalie = new Person { Id = 21, FirstName = "Amalie", LastName = "Gran", BirthYear = 2017 };
            var Aleks = new Person { Id = 22, FirstName = "Aleksander", LastName = "Gran", BirthYear = 1989 };
            var Eline = new Person { Id = 23, FirstName = "Eline", LastName = "Strange Nilsen", BirthYear = 2012 };

            Amalie.Mother = Lena;
            Amalie.Father = Aleks;
            Eline.Father = Aleks;
            Lena.Father = Bjørnar;
            Lena.Mother = Jeanette;
            //Ole.Father = " ";
            Ole.Mother = Jeanette;
            Malin.Father = Bjørnar;
            Malin.Mother = Jeanette;
            Veronika.Father = Bjørnar;
            Veronika.Mother = Brit;
            Ronja.Father = Bjørnar;
            Ronja.Mother = Brit;
            Bjørnar.Mother = Grethe;
            Bjørnar.Father = Trygve;
            Jeanette.Father = Jan;
            Jeanette.Mother = Rita;
            Trygve.Father = Sverre;
            Trygve.Mother = Hella;
            Grethe.Father = Gustav;
            Grethe.Mother = Ruth;
            Jan.Father = Adolf;
            Jan.Mother = Astrid;
            Rita.Father = Bjarne;
            Rita.Mother = Laila;

            var NameList = new List<Person>
            {
                Lena, Ole, Malin, Veronika, Ronja, Bjørnar, Jeanette, Brit, Trygve, Grethe, 
                Jan, Rita, Hella, Sverre, Ruth, Gustav, Laila, Bjarne, Astrid, Adolf,Amalie, Aleks, Eline,
                

            };

            return NameList;
        }

        private static void Commands()
        {
            const string text = 
                                "  liste => Lister alle personer med id, fornavn, fødselsår, dødsår og navn og id på foreldre som er registrert.\n" +
                                "  vis < id nummer > => Viser en bestemt person med navn og ID for foreldre og barn";
            Console.WriteLine(text);
        }
    }
}