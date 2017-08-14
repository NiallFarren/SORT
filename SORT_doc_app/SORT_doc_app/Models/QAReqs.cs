using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SORT_doc_app.Models
{
    public class QAReqs
    {
        public int ID { get; set; }
        [ForeignKey("Project")]
        public int ProjectID { get; set; }
        [DataType(DataType.MultilineText)]
        public string QAContacts { get; set; }
        [DataType(DataType.MultilineText)]
        public string QATeam { get; set; }
        [DataType(DataType.MultilineText)]
        public string QAFramework { get; set; }
        [DataType(DataType.MultilineText)]
        public string QASmokeTest { get; set; }
        [DataType(DataType.MultilineText)]
        public string QALocation { get; set; }
        [DataType(DataType.MultilineText)]
        public string QAHandestsSIMs { get; set; }
        [DataType(DataType.MultilineText)]
        public string QAIssues { get; set; }
        [DataType(DataType.MultilineText)]
        public string QAJira { get; set; }
        [DataType(DataType.MultilineText)]
        public string QAPlan { get; set; }
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }

        public virtual Project Project { get; set; }
    }
}