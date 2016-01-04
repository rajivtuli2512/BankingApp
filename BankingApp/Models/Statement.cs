using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankingApp.Models
{
    public class Statement
    {
        public String Account { get; set; }
        public int tran_id { get; set; }
        public int Credit { get; set; }
        public int Debit { get; set; }
        public int Balance { get; set; }
        public DateTime Updatedat { get; set; }
        public String comment { get; set; }

    }
}