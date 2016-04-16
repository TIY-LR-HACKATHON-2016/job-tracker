using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobTracker.Web.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Resume { get; set; }
        public string CoverLetter { get; set; }
        public string Address { get; set; }
        public string PhoneNum { get; set; }
        [Required]
        public string Email { get; set; }

        public virtual ICollection<Interview> Interviews { get; set; } = new List<Interviews>();
        public virtual ICollection<Job> Jobs { get; set; } = new List<Job>(); 


    }
}