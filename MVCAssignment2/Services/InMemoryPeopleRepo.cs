using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCAssignment2.Interfaces;
using MVCAssignment2.Models;

namespace MVCAssignment2.Services
{
    public class InMemoryPeopleRepo : IPeopleRepo
    {
        private static List<Person> people = new List<Person>();
        private static int idCounter;

        public InMemoryPeopleRepo()
        {
            if (people.Count == 0)
            {
             /*  Create(new Person {Name = "Lina", City = "Barcelona", Phone = "0000-00000" });
                Create(new Person { Name = "Summer", City = "Karlskrona", Phone = "04455-55555" });
                Create(new Person { Name = "Cam", City = "Sorcha" });
                Create(new Person { Name = "Victoria", City = "London", Phone = "+00-000-00000000" });
            */
                }
        }
        public Person Create(Person person)
        {
            if (!String.IsNullOrWhiteSpace(person.Name))
            {
                person.Id = ++idCounter;
                people.Add(person);
            }
            return person;
        }

        public List<Person> Read()
        {
            return people;
        }

        public Person Read(int id)
        {
            return people.Find(p => p.Id == id);
        }

        public bool Update(Person person)
        {
            bool result = false;
            if (person != null || person.Id != 0)
            {
                int index = people.FindIndex(p => p.Id == person.Id);
                if (index >= 0)
                {
                    people[index] = person;
                    result = (people[index] == person) ? true : false;
                }
            }
            return result;
        }
        public bool Delete(Person person)
        {
            return people.Remove(person);
        }
    }
}
