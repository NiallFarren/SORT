using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SORT_doc_app.Models
{
    public class PBX
    {
        public int ID { get; set; }
        [ForeignKey("Project")]
        public int ProjectID { get; set; }
        [DataType(DataType.MultilineText)]
        public string PBXContacts { get; set; }
        [DataType(DataType.MultilineText)]
        public string PBXPhysAddress { get; set; }
        [DataType(DataType.MultilineText)]
        public string PBXTestPhone { get; set; }
        [DataType(DataType.MultilineText)]
        public string PBXShipSend { get; set; }
        [DataType(DataType.MultilineText)]
        public string PBXExtConf { get; set; }
        [DataType(DataType.MultilineText)]
        public string PBX911 { get; set; }
        [DataType(DataType.MultilineText)]
        public string PBXDisconnect { get; set; }
        [DataType(DataType.MultilineText)]
        public string PBXAuthorised { get; set; }
        [DataType(DataType.MultilineText)]
        public string PBXCollab { get; set; }
        [DataType(DataType.MultilineText)]
        public string PBXDSCIMSA { get; set; }
        [DataType(DataType.MultilineText)]
        public string PBXComments { get; set; }

        public virtual Project Project { get; set; }

    }
}