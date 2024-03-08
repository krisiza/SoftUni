using System;
namespace BankLoan.Models
{
    public class Student : Client
    {
        private const int interestDefault = 2;
        public Student(string name, string id, double income) 
            : base(name, id, interestDefault, income)
        {
        }

        public override void IncreaseInterest() => Interest += 1;
    }
}
