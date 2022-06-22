using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCAssignment2.Data;
using MVCAssignment2.Interfaces;

namespace MVCAssignment2.Models
{
    
    public class DatabasePeopleRepo : IPeopleRepo
    {
       
        private readonly PeopleDbContext peopleDb;
        public DatabasePeopleRepo(PeopleDbContext pDb)
        {
            peopleDb = pDb;
        }
        public Person Create(Person person)
        {
            peopleDb.People.Add(person);

            peopleDb.SaveChanges();

            return person;
        }

        public bool Delete(Person person)
        {
            peopleDb.People.Remove(person);
            return (peopleDb.SaveChanges() > 0);
        }

        public List<Person> Read()
        {
            return peopleDb.People.Include(p=>p.City).ThenInclude(p=>p.Country).ToList(); //Include(p => p.City).
        }

        public Person Read(int id)
        {
            return peopleDb.People.SingleOrDefault(person => person.Id == id);
        }

        public bool Update(Person person)
        {
            peopleDb.Entry(person).State = EntityState.Modified;
            return (peopleDb.SaveChanges()>0);
        }
    }
}
