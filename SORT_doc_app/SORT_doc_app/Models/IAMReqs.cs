using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SORT_doc_app.Models
{
    public class IAMReqs
    {
        public int ID { get; set; }
        [ForeignKey("Project")]
        public int ProjectID { get; set; }
        [DataType(DataType.MultilineText)]
        public string IAMContacts { get; set; }
        [DataType(DataType.MultilineText)]
        public string IAMTraining { get; set; }
        [DataType(DataType.MultilineText)]
        public string IAMSummary { get; set; }
        [DataType(DataType.MultilineText)]
        public string IAMApproval { get; set; }
        [DataType(DataType.MultilineText)]
        public string IAMUserAccess { get; set; }
        [DataType(DataType.MultilineText)]
        public string IAMUrls { get; set; }
        [DataType(DataType.MultilineText)]
        public string IAMPassword { get; set; }
        [DataType(DataType.MultilineText)]
        public string IAMAccLockout { get; set; }
        [DataType(DataType.MultilineText)]
        public string IAMOLA { get; set; }
        [DataType(DataType.MultilineText)]
        public string IAMPermission { get; set; }
        [DataType(DataType.MultilineText)]
        public string IAMComments { get; set; }

        public virtual Project Project { get; set; }
    }
}