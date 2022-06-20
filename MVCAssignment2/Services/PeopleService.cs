using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCAssignment2.Interfaces;
using MVCAssignment2.Models;

namespace MVCAssignment2.Services
{
    public class PeopleService: IPeopleService

    {
        private readonly IPeopleRepo inMemoryPeopleRepo;

        public PeopleService(IPeopleRepo peopleRepo)
        {
            inMemoryPeopleRepo = peopleRepo;
        }

        public Person Add(CreatePersonViewModel person)
        {
            return inMemoryPeopleRepo.Create(new Person() { Name = person.Name, Phone = person.Phone, City = person.City }) ;
        }

        public List<Person> All()
        {
            return inMemoryPeopleRepo.Read();
        }

        public bool Edit(int id, CreatePersonViewModel person)
        {
            return inMemoryPeopleRepo.Update( new Person() { Id = id, Name = person.Name, Phone = person.Phone, City = person.City });
        }

        public Person FindById(int id)
        {
            return inMemoryPeopleRepo.Read(id);
        }

        public bool Remove(int id)
        {
            return inMemoryPeopleRepo.Delete(inMemoryPeopleRepo.Read(id));
        }

        public List<Person> Search(string search)
        {
            List<Person> result = new List<Person>();
            if (!string.IsNullOrWhiteSpace(search))
            {
                foreach (Person person in inMemoryPeopleRepo.Read())
                {
                    if (person.Name.ToLower().Contains(search.ToLower()) ||
                        person.City.ToLower().Contains(search.ToLower()))
                    {
                        result.Add(person);
                    }
                }
            }

            return result;
        }
    }
}
