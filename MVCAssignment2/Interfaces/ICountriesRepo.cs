using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCAssignment2.Models;

namespace MVCAssignment2.Interfaces
{
    public interface ICountriesRepo
    {
        Country Create(Country Country);
        List<Country> Read();
        Country Read(int id);

        Country Read(string country);

        bool Update(Country country);
        bool Delete(Country country);
    }
}
