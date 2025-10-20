using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesPoint.Models
{
    public class User
    {
        public int Id { get; set; }
        public bool userDisabled { get; set; }
        public string userName { get; set; }
        public string userLogin { get; set; }
        public string userPassword { get; set; }
        public DateTime lastPasswordChangeDate { get; set; }
        public DateTime lastLoginDate { get; set; }
        public DateTime createDate {get; set; }
        public int kind { get; set; }
    }
}
