using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SORT_doc_app.Models
{
    public class ServiceSpecifics
    {
        public int ID { get; set; }
        [ForeignKey("Project")]
        public int ProjectID { get; set; }
        [DataType(DataType.MultilineText)]
        public string Links { get; set; }
        [DataType(DataType.MultilineText)]
        public string VPN { get; set; }
        [DataType(DataType.MultilineText)]
        public string HostPlatform { get; set; }
        [DataType(DataType.MultilineText)]
        public string BackupRecovery { get; set; }
        [DataType(DataType.MultilineText)]
        public string NotesAndGrid { get; set; }
        [DataType(DataType.MultilineText)]
        public string Changes { get; set;}
        [DataType(DataType.MultilineText)]
        public string GoLiveReqs { get; set; }
        [DataType(DataType.MultilineText)]
        public string SLAsSOW { get; set; }
        [DataType(DataType.MultilineText)]
        public string LicensingAndHardware { get; set; }
        [DataType(DataType.MultilineText)]
        public string BCorDR { get; set; }
        [DataType(DataType.MultilineText)]
        public string SSComments { get; set; }

        public virtual Project Project { get; set; }
    }
}