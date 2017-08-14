using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SORT_doc_app.Models
{
    public class Event
    {
        [Display(Name = "Created At")]
        private DateTime Date = DateTime.Now;

        [Display(Name = "Created At")]
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
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public string EventType { get; set; }
        [Required(ErrorMessage = "Please Enter a Comment Text")]
        [StringLength(160)]
        [DataType(DataType.MultilineText)]
        public string EventBody { get; set; }

        public virtual Project Project { get; set; }
    }
}