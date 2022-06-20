using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MVCAssignment2.Interfaces;
using MVCAssignment2.Models;

namespace MVCAssignment2.Controllers
{
    public class AjaxController : Controller
    {
        private readonly IPeopleService peopleService;
        public AjaxController(IPeopleService peopServ)
        {
            peopleService = peopServ;
        }
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
