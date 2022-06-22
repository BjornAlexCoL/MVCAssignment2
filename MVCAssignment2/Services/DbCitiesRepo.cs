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
    public class DbCitiesRepo : ICitiesRepo
    {
        private readonly PeopleDbContext peopleDb;
        public DbCitiesRepo(PeopleDbContext pDb)
        {
            peopleDb = pDb;
        }
        public City Create(City city)
        {
            if (!String.IsNullOrWhiteSpace(city.Caption) && (Read(city) == null))
            {
                peopleDb.Cities.Add(city);

                peopleDb.SaveChanges();

            }
            return city;
        }

        public bool Delete(City city)
        {
            if (!String.IsNullOrWhiteSpace(city.Caption))
            {
                peopleDb.Cities.Remove(city);
            }
            return (peopleDb.SaveChanges() > 0);
        }

        public List<City> Read()
        {
            return peopleDb.Cities.ToList();
        }

        public City Read(int id)
        {
            return peopleDb.Cities.SingleOrDefault(city => city.Id == id );
        }

        public City Read(string caption)
        {
            return peopleDb.Cities.SingleOrDefault(city => city.Caption == caption );
        }
        public City Read(City city)
        {
            return peopleDb.Cities.SingleOrDefault(cityCountry => (cityCountry.Caption == city.Caption) && (cityCountry.CountryId==city.CountryId) );
        }

        public bool Update(City city)
        {
            peopleDb.Entry(city).State = EntityState.Modified;
            return (peopleDb.SaveChanges() > 0);
        }
    }
}
