using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SORT_doc_app.Models
{
    public class SREReqs
    {
        public int ID { get; set; }
        [ForeignKey("Project")]
        public int ProjectID { get; set; }
        [DataType(DataType.MultilineText)]
        public string SREYesNo { get; set; }
        [DataType(DataType.MultilineText)]
        public string SREYContacts { get; set; }
        [DataType(DataType.MultilineText)]
        public string SREDocument{ get; set; }
        [DataType(DataType.MultilineText)]
        public string SREPasswords { get; set; }

        public virtual Project Project { get; set; }

    }
}