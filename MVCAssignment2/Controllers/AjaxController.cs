
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCAssignment2.Models;
using MVCAssignment2.Services;

namespace MVCAssignment2.Controllers
{
    public class AjaxController : Controller
    {
        PeopleService peopleService = new PeopleService();

        public IActionResult Index()
        {
            return View();
        }

        public List<Person> FetchPeople()
        {
            
            return peopleService.All();
        }
        [HttpPost]
        public Person Display(int id)
        {

            return peopleService.FindById(id);
        }

        [HttpPost]
        public bool Delete(int id)
        {
            return peopleService.Remove(id);
        }

    }
}
