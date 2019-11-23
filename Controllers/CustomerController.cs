using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Assignment.Models;

namespace Assignment.Controllers
{
    public class CustomerController : Controller
    {
        private Context context;

        public CustomerController(Context context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("api/[action]")]
        public IActionResult GetList()
        {
            List<Customer> Customers = context.Customers.OrderByDescending(c => c.Registered).ThenBy(c => c.Name).ToList();
            return Ok(JsonConvert.SerializeObject(Customers, Formatting.Indented));
        }
        [HttpGet("[action]")]
        public IActionResult Form()
        {
            return View();
        }
        [HttpPost("[action]")]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Customer NewCustomer)
        {
            if (NewCustomer.DayOne == false && NewCustomer.DayTwo == false && NewCustomer.DayThree == false)
            {
                ModelState.AddModelError("DaysAttending", "Please select at least one day.");
            }
            if(ModelState.IsValid)
            {
                context.Add(NewCustomer);
                context.SaveChanges();
                return RedirectToAction("Index", "Customer");
            }
            return View("Form");
        }
    }
}
