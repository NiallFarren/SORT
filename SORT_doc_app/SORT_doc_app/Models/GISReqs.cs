using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SORT_doc_app.Models
{
    public class GISReqs
    {
        public int ID { get; set; }
        [ForeignKey("Project")]
        public int ProjectID { get; set; }
        [DataType(DataType.MultilineText)]
        public string GISQAPersonnel { get; set; }
        [DataType(DataType.MultilineText)]
        public string GISArchReview { get; set; }
        [DataType(DataType.MultilineText)]
        public string GISSecInfra { get; set; }
        [DataType(DataType.MultilineText)]
        public string GISVulnerabilityScan { get; set; }
        [DataType(DataType.MultilineText)]
        public string GISEventTool { get; set; }
        [DataType(DataType.MultilineText)]
        public string GISIntrusionDetect { get; set; }
        [DataType(DataType.MultilineText)]
        public string GISHardening { get; set; }
        [DataType(DataType.MultilineText)]
        public string GISAdditional { get; set; }
        //public string GISProcessReview { get; set; }
        [DataType(DataType.MultilineText)]
        public string GISDataClassification { get; set; }
        [DataType(DataType.MultilineText)]
        public string GISEncryption { get; set; }
        [DataType(DataType.MultilineText)]
        public string GISProcess { get; set; }
        [DataType(DataType.MultilineText)]
        public string GISAccess { get; set; }
        [DataType(DataType.MultilineText)]
        public string GISSourceAssure { get; set; }
        [DataType(DataType.MultilineText)]
        public string GISPenetration { get; set; }
        [DataType(DataType.MultilineText)]
        public string GISComments { get; set; }

        public virtual Project Project { get; set; }
    }
}