using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignment2.Models
{
    public class City
    {
        public City()
        {
            People = new List<Person>();
        }
        [Key]
        public int Id { get; set; }
        public string Caption { get; set;}

        public Nullable<int> CountryId;
        public virtual List<Person> People { get; set; }
       public virtual Country Country { get; set; }
    }
}
