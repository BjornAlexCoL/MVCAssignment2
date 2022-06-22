using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCAssignment2.Models;

namespace MVCAssignment2.Interfaces
{
    public interface ICitiesRepo
    {

        City Create(City city);
        List<City> Read();
        City Read(int id);

        City Read(string city);
        City Read(City city);
        bool Update(City city);
        bool Delete(City city);
    }
}
