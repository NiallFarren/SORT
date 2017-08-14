using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SORT_doc_app.Models
{
    public class NEReqs
    {
        public int ID { get; set; }
        [ForeignKey("Project")]
        public int ProjectID { get; set; }
        [DataType(DataType.MultilineText)]
        public string NEYesNo { get; set; }
        [DataType(DataType.MultilineText)]
        public string NEChangeContact { get; set; }
        [DataType(DataType.MultilineText)]
        public string NEChangeDescription { get; set; }
        [DataType(DataType.MultilineText)]
        public string NEChangeLocation { get; set; }
        [DataType(DataType.MultilineText)]
        public string NEChangeIPInfo { get; set; }
        [DataType(DataType.MultilineText)]
        public string NEChangeReasonResult { get; set; }
        [DataType(DataType.MultilineText)]
        public string NEChangeSummary { get; set; }
        [DataType(DataType.MultilineText)]
        public string NEServiceContact { get; set; }
        [DataType(DataType.MultilineText)]
        public string NEServiceDescription { get; set; }
        [DataType(DataType.MultilineText)]
        public string NEServiceLocation { get; set; }
        [DataType(DataType.MultilineText)]
        public string NEServiceIPInfo { get; set; }
        [DataType(DataType.MultilineText)]
        public string NEServiceResult { get; set; }
        [DataType(DataType.MultilineText)]
        public string NEServiceSummary { get; set; }
        [DataType(DataType.MultilineText)]
        public string NEAcqMigrDomain { get; set; }
        [DataType(DataType.MultilineText)]
        public string NEAcqMigrDNS { get; set; }
        [DataType(DataType.MultilineText)]
        public string NEAcqTunnels { get; set; }
        [DataType(DataType.MultilineText)]
        public string NEAcqSummary { get; set; }
        [DataType(DataType.MultilineText)]
        public string NENewConfirmConnectivity{ get; set; }
        [DataType(DataType.MultilineText)]
        public string NENewSummary { get; set; }
        [DataType(DataType.MultilineText)]
        public string NEEnvironment { get; set; }
        [DataType(DataType.MultilineText)]
        public string NEComments { get; set; }

        public virtual Project Project { get; set; }
    }
}