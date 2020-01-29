using System;
using System.Collections.Generic;

namespace testOb
{
    internal class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MaidenName { get; set; }
        public int BirthYear { get; set; }
        public int DeathYear { get; set; }
        public Person Father { get; set; }
        public Person Mother { get; set; }


        internal void InfoList()
        {
            var output = $"ID: {Id}, Fornavn: {FirstName}";

            if (LastName != null) { output += $", Etternavn: {LastName}"; }

            output += $", Fødselsår: {BirthYear}";
            if (DeathYear != null && DeathYear != 0) { output += $", Dødsår: {DeathYear}"; }

            if (Father != null) { output += $", Far: {Father.FirstName}, Far ID: {Father.Id}"; }
            if (Mother != null) { output += $", Mor: {Mother.FirstName}, Mor ID: {Mother.Id}"; }

            Console.WriteLine("  " + output);
        }

        public void InfoPerson (List<Person> liste)
        {
            var children = new List<Person>();
            foreach (var person in liste)
            {
                if (person.Father != null && person.Father.Id == Id)
                {
                    children.Add(person);
                }
                if (person.Mother != null && person.Mother.Id == Id)
                {
                    children.Add(person);
                }
            }


            var output = $"  ID: {Id}, Fornavn: {FirstName}";

            if (LastName != null) { output += $", Etternavn: {LastName}"; }

            output += $", Fødselsår: {BirthYear}\n";

            if (Father != null || Mother != null)
            {
                output += "  Foreldre:\n";
                if (Father != null) { output += $"    Far: {Father.FirstName} (ID: {Father.Id})\n"; }
                if (Mother != null) { output += $"    Mor: {Mother.FirstName} (ID: {Mother.Id})\n"; }
            }

            if (children.Count > 0)
            {
                output += "  Barn:\n";
                foreach (var child in children)
                {
                    output += $"    {child.FirstName} (ID: {child.Id})\n";
                }
            }

            Console.WriteLine(output);
        }
    }
}