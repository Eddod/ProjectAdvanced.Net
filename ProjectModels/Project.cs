using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectModels
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string ProjectDescription { get; set; }
        public ICollection<TimeReport> TimeReports { get; set; }
    }
}
