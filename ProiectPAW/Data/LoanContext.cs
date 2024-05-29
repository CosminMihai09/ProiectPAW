using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ProiectPAW.Classes;

namespace ProiectPAW.Data
{
    public class LoanContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Loan> Loans { get; set; }

        public LoanContext() : base("name=LoanContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<LoanContext>());
        }
    }
}
