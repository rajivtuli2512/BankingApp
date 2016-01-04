namespace BankingApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    //[Table("Login")]
    public partial class Login
    {
        [Key]
        [DisplayName("Login")]
        public String UserID { get; set; }

        [Required]
        [DisplayName("Password")]
        public String Password { get; set; }
    }
}
