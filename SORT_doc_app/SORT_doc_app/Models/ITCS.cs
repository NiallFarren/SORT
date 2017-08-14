using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SORT_doc_app.Models
{
    public class ITCS
    {
        public int ID { get; set; }
        [ForeignKey("Project")]
        public int ProjectID { get; set; }
        [DataType(DataType.MultilineText)]
        public string ITCSContacts { get; set; }
        [DataType(DataType.MultilineText)]
        public string ITCSEmail { get; set; }
        [DataType(DataType.MultilineText)]
        public string ITCSDomains { get; set; }
        [DataType(DataType.MultilineText)]
        public string ITCSSoftware { get; set; }
        [DataType(DataType.MultilineText)]
        public string ITCSBuying { get; set; }
        [DataType(DataType.MultilineText)]
        public string ITCSOwner { get; set; }
        [DataType(DataType.MultilineText)]
        public string ITCSEmailConfig { get; set; }
        [DataType(DataType.MultilineText)]
        public string ITCSInventory { get; set; }
        [DataType(DataType.MultilineText)]
        public string ITCSListing { get; set; }
        [DataType(DataType.MultilineText)]
        public string ITCSComments { get; set; }

        public virtual Project Project { get; set; }
    }
}