using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using JobTracker.Web.Models;

namespace JobTracker.Web.Controllers

{
    public class JobsController : Controller
    {
        private readonly JobTrackerWebDbContext db = new JobTrackerWebDbContext();

        // GET: Jobs
        public ActionResult Index()
        {
            return Json(db.Jobs.ToList(), JsonRequestBehavior.AllowGet);
        }


        // GET: Jobs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return Json(job, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(CreateJobVM vm)
        {
            if (!ModelState.IsValid)
            {
                var errorList = (from item in ModelState
                    where item.Value.Errors.Any()
                    select item.Value.Errors[0].ErrorMessage).ToList();
                return Json(errorList);
            }

            var newJob = new Job
            {
                JobTitle = vm.JobTitle,
                CompanyTitle = vm.CompanyTitle,
                Address = vm.Address,
                Status = vm.Status,
                Url = vm.Url,
                Description = vm.Description,
                PhoneNumber = vm.PhoneNumber,
                Date = vm.Date
            };

            db.Jobs.Add(newJob);
            db.SaveChanges();


            return Json(newJob);
        }


        // GET: Jobs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return Json(job, JsonRequestBehavior.AllowGet);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "Id,UserId,CompanyTitle,Url,Date,JobTitle,PhoneNumber,Address,Description")] Job job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return Json(job, JsonRequestBehavior.AllowGet);
        }

        // GET: Jobs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return Json(job, JsonRequestBehavior.AllowGet);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var job = db.Jobs.Find(id);
            db.Jobs.Remove(job);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}