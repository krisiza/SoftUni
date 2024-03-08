namespace BankLoan.Models
{
    public class MortgageLoan : Loan
    {
        private const int interestrate = 3;
        private const double creditAmount = 50000;
        public MortgageLoan() 
            : base(interestrate, creditAmount)
        {
        }
    }
}
