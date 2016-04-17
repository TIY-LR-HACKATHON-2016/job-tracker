using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JobTracker.Web.Models
{
    public class Job
    {
        public int Id { get; set; }
        public virtual User User { get; set; }

        [Required]
        public string CompanyTitle { get; set; }

        public string Url { get; set; }

        [Required]
        public string JobTitle { get; set; }

        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public JobStatus Status { get; set; }
        public DateTime StatusDate { get; set; }


        [Required]
        public string Description { get; set; }

        public DateTime Created { get; set; }

        public virtual ICollection<Interview> Interviews { get; set; } = new List<Interview>();
    }

    public enum JobStatus
    {
        Saved = 0,
        Applied = 1,
        Scheduled = 2,
        Interviewed = 3,
        Declined = 4,
        Hired = 5
    }
}