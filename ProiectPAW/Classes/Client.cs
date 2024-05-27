using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectPAW.Classes
{
    internal class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateAdded { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }

        [NotMapped]
        public int LoanCount
        {
            get { return Loans?.Count ?? 0; }
        }
    }
}
