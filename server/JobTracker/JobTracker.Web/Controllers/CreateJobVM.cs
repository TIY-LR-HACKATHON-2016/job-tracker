using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JobTracker.Web.Models;

namespace JobTracker.Web.Controllers
{
    public class CreateJobVM
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string CompanyTitle { get; set; }
        public string Url { get; set; }
        public DateTime Date { get; set; }
        public string JobTitle { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Interview> Interviews { get; set; } = new List<Interview>();
    }
}