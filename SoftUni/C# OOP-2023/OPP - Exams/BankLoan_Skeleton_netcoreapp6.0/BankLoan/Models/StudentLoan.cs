namespace BankLoan.Models
{
    public class StudentLoan : Loan
    {
        private const int interestrate = 1;
        private const double creditAmount = 10000;
        public StudentLoan() 
            : base(interestrate, creditAmount)
        {
        }
    }
}
