using System.Linq;
using System.Web.Mvc;
using Faker;
using JobTracker.Web.Models;

namespace JobTracker.Web.Controllers
{
    public class UsersController : Controller
    {
        private JobTrackerWebDbContext db = new JobTrackerWebDbContext();

        [HttpGet]
        public ActionResult About()
        {
            var user = db.Users.First();
            var model = new
            {
                user.Address,
                user.Email,
                user.FirstName,
                user.LastName,
                user.PhoneNum,
                user.Resume,
                user.CoverLetter,
                user.Id
            };
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}