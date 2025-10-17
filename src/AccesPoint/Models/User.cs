using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesPoint.Models
{
    public class User
    {
        public string Id { get; set; }
        public bool userDisabled { get; set; }
        public string userName { get; set; }
        public string userLogin { get; set; }
        public string userPassword { get; set; }
        public string lastPasswordChangeDate { get; set; }
        public string lastLoginDate { get; set; }
        public string createDate { get; set; }
        public string kind { get; set; }
    }
}
