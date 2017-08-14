using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SORT_doc_app.Models
{
    public class UserProfile
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Group { get; set; }
    }
}