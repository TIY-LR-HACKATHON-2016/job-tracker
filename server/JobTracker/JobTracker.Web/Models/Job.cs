using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace JobTracker.Web.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [Required]
        public string CompanyTitle { get; set; }
        public string Url { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string JobTitle { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        [Required]
        public string Description { get; set; }

        public virtual ICollection<Interview> Interviews { get; set; } = new List<Interview>();
    }
}