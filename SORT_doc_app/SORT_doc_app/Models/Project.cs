using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SORT_doc_app.Models
{
    public class Project
    {
        [Key]
        public int ID { get; set; }
        public string UserID { get; set; }
        [Display(Name = "Author")]
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Created At")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        private DateTime Date = DateTime.Now;

        [DataType(DataType.Date)]
        [Display(Name = "Created At")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
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

        [DataType(DataType.Date)]
        [Display(Name = "Projected Go Live Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime GoLiveDate { get; set; }
        public string Status { get; set; }

        public bool Open { get; set; }
        public bool SummaryDone { get; set; }
        public bool ServSpecDone { get; set; }
        public bool EOCDone { get; set; }
        public bool AppSupportDone { get; set; }
        public bool ChangeManDone { get; set; }
        public bool GISDone { get; set; }
        public bool NEDone { get; set; }
        public bool SCVDone { get; set; }
        public bool SREDone { get; set; }
        public bool DBADone { get; set; }
        public bool QADone { get; set; }
        public bool IAMDone { get; set; }
        public bool PBXDone { get; set; }
        public bool ITCSDone { get; set; }
        public bool SMODone { get; set; }
        public bool RisksDone { get; set; }
        public bool SignOffDone { get; set; }
    }
}