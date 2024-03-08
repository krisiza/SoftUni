namespace BankLoan.Models
{
    public class BranchBank : Bank
    {
        private const int capacityDefault = 25;
        public BranchBank(string name) 
            : base(name, capacityDefault)
        {
        }
    }
}
