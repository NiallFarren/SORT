using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SORT_doc_app.Models
{
    public class DBAReqs
    {
        public int ID { get; set; }
        [ForeignKey("Project")]
        public int ProjectID { get; set; }
        [DataType(DataType.MultilineText)]
        public string DBAYesNo { get; set; }
        [DataType(DataType.MultilineText)]
        public string DBAContacts { get; set; }
        [DataType(DataType.MultilineText)]
        public string DBADbInstance { get; set; }
        [DataType(DataType.MultilineText)]
        public string DBADbVersion { get; set; }
        [DataType(DataType.MultilineText)]
        public string DBADbOS { get; set; }
        [DataType(DataType.MultilineText)]
        public string DBAUserIDs { get; set; }
        [DataType(DataType.MultilineText)]
        public string DBALinks { get; set; }
        [DataType(DataType.MultilineText)]
        public string DBAFeatures { get; set; }
        [DataType(DataType.MultilineText)]
        public string DBAAppTouchPoints { get; set; }
        [DataType(DataType.MultilineText)]
        public string DBADbTouchPoints { get; set; }
        [DataType(DataType.MultilineText)]
        public string DBAVolumeEstimates { get; set; }
        [DataType(DataType.MultilineText)]
        public string DBAUserVolume{ get; set; }
        [DataType(DataType.MultilineText)]
        public string DBAArchPurging { get; set; }
        [DataType(DataType.MultilineText)]
        public string DBAPools { get; set; }
        [DataType(DataType.MultilineText)]
        public string DBACRUDMatrix { get; set; }
        [DataType(DataType.MultilineText)]
        public string DBAPerformance { get; set; }
        [DataType(DataType.MultilineText)]
        public string DBADBMSJobs { get; set; }
        [DataType(DataType.MultilineText)]
        public string DBARollback { get; set; }
        [DataType(DataType.MultilineText)]
        public string DBARollbackTest { get; set; }
        [DataType(DataType.MultilineText)]
        public string DBABRProcess { get; set; }
        [DataType(DataType.MultilineText)]
        public string DBABackupReqs { get; set; }
        [DataType(DataType.MultilineText)]
        public string DBARecoveryReqs { get; set; }
        [DataType(DataType.MultilineText)]
        public string DBARetentionReqs { get; set; }
        [DataType(DataType.MultilineText)]
        public string DBAComments { get; set; }

        public virtual Project Project { get; set; }
    }
}