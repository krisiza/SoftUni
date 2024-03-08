using BankLoan.Models.Contracts;
using System;

namespace BankLoan.Models
{
    public class Adult : Client
    {
        private const int interestDefault = 4;
        public Adult(string name, string id, double income) 
            : base(name, id, interestDefault, income)
        {
        }

        public override void IncreaseInterest() => Interest += 2;
    }
}
