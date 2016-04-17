using System;
using Microsoft.ApplicationInsights.Extensibility.Implementation;

namespace JobTracker.Web.Models
{
    public class Interview
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public virtual Job Job { get; set; }
        public virtual User User  { get; set; }
        
    }
    
    
}