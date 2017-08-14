using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SORT_doc_app.Models
{
    public class SCVReqs
    {
        public int ID { get; set; }
        [ForeignKey("Project")]
        public int ProjectID { get; set; }
        [DataType(DataType.MultilineText)]
        public string SCVYesNo { get; set; }
        [DataType(DataType.MultilineText)]
        public string SCVIpsCreds { get; set; }
        [DataType(DataType.MultilineText)]
        public string SCVNetwork { get; set; }
        [DataType(DataType.MultilineText)]
        public string SCVInventory { get; set; }
        [DataType(DataType.MultilineText)]
        public string SCVSupport { get; set; }
        [DataType(DataType.MultilineText)]
        public string SCVChangeControl { get; set; }
        [DataType(DataType.MultilineText)]
        public string SCVSecurity { get; set; }
        [DataType(DataType.MultilineText)]
        public string SCVSPOC { get; set; }
        [DataType(DataType.MultilineText)]
        public string SCVCapacity { get; set; }
        [DataType(DataType.MultilineText)]
        public string SCVForecast { get; set; }
        [DataType(DataType.MultilineText)]
        public string SCVTraining { get; set; }
        [DataType(DataType.MultilineText)]
        public string SCVComments { get; set; }

        public virtual Project Project { get; set; }
    }
}