using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SORT_doc_app.Models
{
    public class Assignment
    {
        public int ID { get; set; }
        [ForeignKey("Project")]
        public int ProjectID { get; set; }
        public string Section { get; set; }
        public string Assignee { get; set; }

        [Display(Name = "Created At")]
        private DateTime Date = DateTime.Now;
        [DataType(DataType.Date)]
        [Display(Name = "Assigned At")]
        public DateTime _Date
        {
            get
            {
                return Date;
            }
            set
            {
                Date = value;
            }
        }

        public virtual Project Project { get; set; }
    }
}