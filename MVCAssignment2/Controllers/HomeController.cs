using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCAssignment2.Interfaces;
using MVCAssignment2.Models;
using MVCAssignment2.Services;

namespace MVCAssignment2.Controllers
{
    public class HomeController : Controller
    {

        PeopleService peopleService = new PeopleService();
        public IActionResult Index()
        {
            ViewBag.Message = "Search";
            return View(peopleService.All());
        }


        [HttpPost]
        public IActionResult Index(string search)
        {
            return View(peopleService.Search(search));
        }
        public IActionResult Details(Person person)
        {
            return View(person);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string name, string phone, string city)
        {
            peopleService.Add(new Models.CreatePersonViewModel() { Name = name, Phone = phone, City = city });
            return RedirectToAction("index", "home");
        }
        public IActionResult Delete(Person person)
        {
            peopleService.Remove(person.Id);

            return RedirectToAction("index", "home");
        }


    }
}
