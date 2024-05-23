using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ProiectPAW.Classes;

namespace ProiectPAW.Data
{
    internal class LoanContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Loan> Loans { get; set; }

        public LoanContext() : base("name=LoanContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasMany(c => c.Loans)
                .WithRequired(l => l.Client)
                .HasForeignKey(l => l.ClientId);

            base.OnModelCreating(modelBuilder);
            Console.WriteLine("Aaaa");
        }
    }
}
