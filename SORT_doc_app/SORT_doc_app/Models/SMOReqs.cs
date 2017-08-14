using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SORT_doc_app.Models
{
    public class SMOReqs
    {
        public int ID { get; set; }
        [ForeignKey("Project")]
        public int ProjectID { get; set; }
        [DataType(DataType.MultilineText)]
        public string SMOContracts { get; set; }
        [DataType(DataType.MultilineText)]
        public string SMOTemplates { get; set; }
        [DataType(DataType.MultilineText)]
        public string SMODocuments { get; set; }
        [DataType(DataType.MultilineText)]
        public string SMOBusinessContacts { get; set; }
        [DataType(DataType.MultilineText)]
        public string SMOChangeManagement { get; set; }
        [DataType(DataType.MultilineText)]
        public string SMOIncidentManagement { get; set; }
        [DataType(DataType.MultilineText)]
        public string SMOUsage { get; set; }
        [DataType(DataType.MultilineText)]
        public string SMOKPIsSLAs { get; set; }
        [DataType(DataType.MultilineText)]
        public string SMOSLMReporting { get; set; }
        [DataType(DataType.MultilineText)]
        public string SMOChReports{ get; set; }
        [DataType(DataType.MultilineText)]
        public string SMOIPMRdefined { get; set; }
        [DataType(DataType.MultilineText)]
        public string SMOProgManagement { get; set; }
        [DataType(DataType.MultilineText)]
        public string SMOChManagementTicketing { get; set; }
        [DataType(DataType.MultilineText)]
        public string SMOKPIProbes { get; set; }
        [DataType(DataType.MultilineText)]
        public string SMOComments { get; set; }

        public virtual Project Project { get; set; }
    }
}