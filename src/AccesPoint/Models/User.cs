using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Runtime;
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
        public DateTime? lastPasswordChangeDate { get; set; } = null;
        public DateTime? lastLoginDate { get; set; } = null;
        public DateTime? createDate { get; set; } = null;
        public int kind { get; set; }
        public byte[] avatarBinary { get; set; }

    }
}
