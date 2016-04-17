using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobTracker.Web.Models;

namespace JobTracker.Web.Controllers
{
    public class UsersController : Controller
    {
        private JobTrackerWebDbContext db = new JobTrackerWebDbContext();

        [HttpGet]
        public ActionResult About( )
        {
            var user = new User
            {
                FirstName = "Nancy",
                LastName = "Majors",
                Email = "nmajors@gmail.com",
                PhoneNum = Faker.Phone.Number(),
                Address = Faker.Address.StreetAddress(),
                Resume = Faker.TextFaker.Sentences(20)
            };

            return Json(user,JsonRequestBehavior.AllowGet);
         }
    }
}
