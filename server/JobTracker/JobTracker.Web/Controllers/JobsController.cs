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
    public class JobsController : Controller
    {
        private JobTrackerWebDbContext db = new JobTrackerWebDbContext();

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
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return Json(job, JsonRequestBehavior.AllowGet);
        }

        //[HttpGet]
        //public ActionResult Create()
        //{
        //    return Json(JsonRequestBehavior.AllowGet);
        //}
        //// GET: Jobs/Create
        /// 
        /// 
        [HttpPost]
        public ActionResult Create(CreateJobVM vm)
        {

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,CompanyTitle,Url,Date,JobTitle,PhoneNumber,Address,Description")] Job job)
        {
                db.Jobs.Select(job => new
            {
                    JobTitle = job.JobTitle,
                    CompanyTitle = job.CompanyTitle,
                    Address = job.Address,
                    Status = job.Status,
                    Url = job.Url,
                    Description = job.Description,
                    PhoneNumber = job.PhoneNumber,
                    Date = job.Date


                });
                db.Jobs.Add(entry);

                return Json(entry, JsonRequestBehavior.AllowGet);



            }
            //{
            //    db.Jobs.Add(newJob);
            //    return RedirectToAction("Index");
            //}
            //else
            //{
            //    return Json(newJob,JsonRequestBehavior.AllowGet);
            //}
            }

            return Json(job);
        }


        // GET: Jobs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
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
        public ActionResult Edit([Bind(Include = "Id,UserId,CompanyTitle,Url,Date,JobTitle,PhoneNumber,Address,Description")] Job job)
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
            Job job = db.Jobs.Find(id);
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
            Job job = db.Jobs.Find(id);
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
