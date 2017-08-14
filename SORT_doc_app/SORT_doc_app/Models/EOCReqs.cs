using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SORT_doc_app.Models
{
    public class EOCReqs
    {
        public int ID { get; set; }
        [ForeignKey("Project")]
        public int ProjectID { get; set; }
        [DataType(DataType.MultilineText)]
        public string EOCContacts { get; set; }
        [DataType(DataType.MultilineText)]
        public string EOCLocation { get; set; }
        [DataType(DataType.MultilineText)]
        public string EOCPOCs { get; set; }
        [DataType(DataType.MultilineText)]
        public string EOCDocsAndDemo { get; set; }
        [DataType(DataType.MultilineText)]
        public string EOCProcessFlows { get; set; }
        [DataType(DataType.MultilineText)]
        public string EOCMonitoring { get; set; }
        [DataType(DataType.MultilineText)]
        public string EOCSignOff { get; set; }
        [DataType(DataType.MultilineText)]
        public string EOCCustomers { get; set; }
        [DataType(DataType.MultilineText)]
        public string EOCSevEmail { get; set; }
        [DataType(DataType.MultilineText)]
        public string EOCCrisis { get; set; }
        [DataType(DataType.MultilineText)]
        public string EOCProcess { get; set; }
        [DataType(DataType.MultilineText)]
        public string EOCExceptions { get; set; }
        [DataType(DataType.MultilineText)]
        public string EOCComments { get; set; }
        public virtual Project Project { get; set; }
    }
}