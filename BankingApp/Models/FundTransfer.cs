using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankingApp.Models
{
    public class FundTransfer
    {
        [Required(ErrorMessage = "Please select From Account")]
        public String FromAccount { get; set; }

        [Required(ErrorMessage = "Please select to Account")]
        public String ToAccount { get; set; }

        public int AvailableBalance { get; set; }

        [Required(ErrorMessage = "Please enter Amount to be transferred.")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "Enter your comments")]
        public String Remarks { get; set; }
        public String UserID { get; set; }


    }
}
    