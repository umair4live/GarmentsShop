using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GShop.UsersMgt
{
    public class UserAccountStatus
    {
        public int Id { get; set; }
        [Required]
        public string AccountStatus { get; set; }
    }
}
