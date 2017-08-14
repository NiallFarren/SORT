using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SORT_doc_app.Models
{
    public class Summary
    {
        public int ID { get; set; }
        [ForeignKey("Project")]
        public int ProjectID { get; set; }
        [Display(Name = "Service Name (include also any Project names)")]
        [DataType(DataType.MultilineText)]
        public string ServiceName { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Display(Name = "Product Name and Release Number")]
        [DataType(DataType.MultilineText)]
        public string ProductName { get; set; }
        [Display(Name = "Service Delivery Manager / Business Team")]
        [DataType(DataType.MultilineText)]
        public string ServiceDelivery { get; set; }
        [Display(Name = "Cost Centre")]
        [DataType(DataType.MultilineText)]
        public string CostCentre { get; set; }
        [Display(Name = "Project Managers")]
        [DataType(DataType.MultilineText)]
        public string ProjectManagers { get; set; }
        [Display(Name = "PCI or SOX application?")]
        [DataType(DataType.MultilineText)]
        public string PCISOX { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Go Live Date(s)")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime GoLiveDate { get; set; }
        [Display(Name = "Primary Architecture Tech Leads and Teams")]
        [DataType(DataType.MultilineText)]
        public string ArchLeadTeams { get; set; }
        [Display(Name = "Primary Technical IT Leads & Teams supporting the environment once live")]
        [DataType(DataType.MultilineText)]
        public string SupportTeams { get; set; }
        [DataType(DataType.MultilineText)]
        public string SummaryComments { get; set; }

        public virtual Project Project { get; set; }
    }
}