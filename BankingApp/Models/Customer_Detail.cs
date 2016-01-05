using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BankingApp.Models
{
    public class Customer_Detail
    {
        [DisplayName("User ID")]
        public String UserID { get; set; }

        [DisplayName("Name")]
        public String Name { get; set; }

        [DisplayName("Email")]
        public String Email { get; set; }

        public String Address { get; set; }

        [DisplayName("Contact Number")]
        public String phonenumber { get; set; }

    }
}