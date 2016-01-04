using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankingApp.Models
{
    public class AccountSummary
    {
        public int Balance { get; set; }
        public String Account { get; set; }
        public String UserID { get; set; }
    }
}