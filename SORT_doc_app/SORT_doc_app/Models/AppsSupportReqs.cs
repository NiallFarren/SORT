using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SORT_doc_app.Models
{
    public class AppsSupportReqs
    {
        public int ID { get; set; }
        [ForeignKey("Project")]
        public int ProjectID { get; set; }
        [DataType(DataType.MultilineText)]
        public string SupContacts { get; set; }
        [DataType(DataType.MultilineText)]
        public string SupAccountsAccess { get; set; }
        [DataType(DataType.MultilineText)]
        public string SupToolsA { get; set; }
        [DataType(DataType.MultilineText)]
        public string SupToolsB { get; set; }
        [DataType(DataType.MultilineText)]
        public string SupToolsC { get; set; }
        [DataType(DataType.MultilineText)]
        public string SupToolsD { get; set; }
        [DataType(DataType.MultilineText)]
        public string SupDemoTraining { get; set; }
        [DataType(DataType.MultilineText)]
        public string SupContactsProvided { get; set; }
        [DataType(DataType.MultilineText)]
        public string SupCustContact { get; set; }
        [DataType(DataType.MultilineText)]
        public string SupComments { get; set; }

        public virtual Project Project { get; set; }

    }
}