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
            var user = new User();
            user.FirstName = "Nancy";
            user.LastName = "Majors";
            user.Email = "nmajors@gmail.com";
            user.PhoneNum = Faker.Phone.Number();
            user.Address = Faker.Address.StreetAddress();
            user.Resume = Faker.TextFaker.Sentences(20);

            return Json(user,JsonRequestBehavior.AllowGet);
         }

    }
}
