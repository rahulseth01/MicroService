using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CustomerService.Models
{
    public partial class Users
    {
        [Key]
        public int Userid { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int? Age { get; set; }
        public string City { get; set; }
        public int? Creditrating { get; set; }
    }
}
