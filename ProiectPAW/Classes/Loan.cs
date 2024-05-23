using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectPAW.Classes
{
    internal class Loan
    {
        public int LoanId { get; set; }
        public decimal Amount { get; set; }
        public decimal InterestRate { get; set; }
        public int DurationMonths { get; set; }
        public int ClientId { get; set; }

        public virtual Client Client { get; set; }
    }
}
