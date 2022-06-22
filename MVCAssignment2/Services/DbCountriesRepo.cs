using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCAssignment2.Data;
using MVCAssignment2.Interfaces;
using MVCAssignment2.Models;

namespace MVCAssignment2.Services
{
    public class DbCountriesRepo : ICountriesRepo
    {
        private readonly PeopleDbContext peopleDb;
        public DbCountriesRepo(PeopleDbContext pDb)
        {
            peopleDb = pDb;
        }
        public Country Create(Country country)
        {
            if(!String.IsNullOrWhiteSpace(country.Caption) && Read(country.Caption) == null)
            {
                peopleDb.Countries.Add(country);

                peopleDb.SaveChanges();

            }
                return country;
        }

        public bool Delete(Country country)
        {
            if (!String.IsNullOrWhiteSpace(country.Caption))
            {
            peopleDb.Countries.Remove(country);
            } 
            return (peopleDb.SaveChanges() > 0);
        }

        public List<Country> Read()
        {
            return peopleDb.Countries.ToList(); 
        }

        public Country Read(int id)
        {
            return peopleDb.Countries.SingleOrDefault(Country => Country.Id == id);

        }

        public Country Read(string caption)
        {
            return peopleDb.Countries.SingleOrDefault(country => country.Caption == caption);
        }

        public bool Update(Country country)
        {
            peopleDb.Entry(country).State = EntityState.Modified;
            return (peopleDb.SaveChanges() > 0);
        }
    }
}
