namespace BankingApp.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using BankingApp.Models;

    public partial class BankingAppDB : DbContext
    {
       public DbSet<Login> Logins { get; set; }
       public DbSet<CustomerAccounts> customeraccounts { get; set; }
       public DbSet<Customer_Detail> Customer_Detail { get; set; }
       public DbSet<Statement> Statements { get; set; }
       public DbSet<AccountSummary> AccountsSummary { get; set; }
       public DbSet<Benefeciries> Benefeciries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Database.SetInitializer<BankingAppDB>(null);

            //Map DB Tables
            modelBuilder.Entity<Login>().ToTable("Login", "dbo");
            modelBuilder.Entity<CustomerAccounts>().ToTable("Customer_Accounts", "dbo").HasKey(o=>o.Account);
            modelBuilder.Entity<Customer_Detail>().ToTable("Customer_Detail", "dbo").HasKey(o => o.UserID);
            modelBuilder.Entity<Statement>().ToTable("Account_transactions", "dbo").HasKey(o => o.tran_id);
            modelBuilder.Entity<AccountSummary>().ToTable("v_Account_Summary", "dbo").HasKey(o => o.Account);
            modelBuilder.Entity<Benefeciries>().ToTable("Benefeciries", "dbo").HasKey(o => o.Account);

        }
    }
}
