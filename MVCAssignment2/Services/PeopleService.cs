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
        private readonly IPeopleRepo peopleRepo;

        public PeopleService(IPeopleRepo peopleRepo)
        {
            this.peopleRepo = peopleRepo;
        }

        public Person Add(CreatePersonViewModel person)
        {
            return peopleRepo.Create(new Person() { Name = person.Name, Phone = person.Phone, CityId = person.CityId }) ;
        }

        public List<Person> All()
        {
            return peopleRepo.Read();
        }

        public bool Edit(int id, CreatePersonViewModel person)
        {
            return peopleRepo.Update( new Person() { Id = id, Name = person.Name, Phone = person.Phone, CityId = person.CityId });
        }

        public Person FindById(int id)
        {
            return peopleRepo.Read(id);
        }

        public bool Remove(int id)
        {
            return peopleRepo.Delete(peopleRepo.Read(id));
        }

        public List<Person> Search(string search)
        {
            List<Person> result = new List<Person>();
            if (!string.IsNullOrWhiteSpace(search))
            {
                foreach (Person person in peopleRepo.Read())
                {
                    if (person.Name.ToLower().Contains(search.ToLower()) ||
                        person.City.Caption.ToLower().Contains(search.ToLower()))
                    {
                        result.Add(person);
                    }
                }
            }

            return result;
        }
    }
}
