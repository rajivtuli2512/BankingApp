using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BankingApp.Models
{
    public class CustomerAccounts
    {
        
        public String UserID { get; set; }

        [DisplayName("Account")]
        public String Account { get; set; }

        [DisplayName("Balance")]
        public int Balance { get; set; }
    }
}