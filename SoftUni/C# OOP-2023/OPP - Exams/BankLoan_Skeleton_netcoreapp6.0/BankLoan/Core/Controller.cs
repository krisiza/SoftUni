using BankLoan.Core.Contracts;
using BankLoan.Models;
using BankLoan.Models.Contracts;
using BankLoan.Repositories;
using BankLoan.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace BankLoan.Core
{
    public class Controller : IController
    {
        private BankRepository banks;
        private LoanRepository loans;

        private List<string> validBankNames = new() { "BranchBank", "CentralBank" };
        private List<string> validLoanNames = new() { "StudentLoan", "MortgageLoan" };
        private List<string> validClientNames = new() { "Student", "Adult" };

        public Controller()
        {
            banks = new BankRepository();
            loans = new LoanRepository();
        }
        public string AddBank(string bankTypeName, string name)
        {
            if (!validBankNames.Contains(bankTypeName))
            {
                throw new ArgumentException(ExceptionMessages.BankTypeInvalid);
            }

            IBank bank = null;
            if (bankTypeName == "BranchBank")
                bank = new BranchBank(name);
            else
                bank = new CentralBank(name);

            banks.AddModel(bank);
            return String.Format(OutputMessages.BankSuccessfullyAdded, bankTypeName);
        }

        public string AddLoan(string loanTypeName)
        {
            if (!validLoanNames.Contains(loanTypeName))
            {
                throw new ArgumentException(ExceptionMessages.LoanTypeInvalid);
            }

            ILoan loan = null;
            if (loanTypeName == "StudentLoan")
                loan = new StudentLoan();
            else
                loan = new MortgageLoan();

            loans.AddModel(loan);
            return String.Format(OutputMessages.LoanSuccessfullyAdded, loanTypeName);
        }
        public string ReturnLoan(string bankName, string loanTypeName)
        {
            IBank bank = banks.Models.FirstOrDefault(b => b.Name == bankName);
            ILoan loan = loans.Models.FirstOrDefault(l => l.GetType().Name == loanTypeName);

            if (loan == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.MissingLoanFromType, loanTypeName));
            }

            loans.RemoveModel(loan);
            bank.AddLoan(loan);

            return String.Format(OutputMessages.LoanReturnedSuccessfully, loanTypeName, bankName);

        }
        public string AddClient(string bankName, string clientTypeName, string clientName, string id, double income)
        {
            if (!validClientNames.Contains(clientTypeName))
            {
                throw new ArgumentException(ExceptionMessages.ClientTypeInvalid);
            }

            IBank bank = banks.Models.FirstOrDefault(c => c.Name == bankName);
            IClient client = null;

            if (bank != null) 
            {
                if (clientTypeName == "Student")
                    client = new Student(clientName,id,income);
                else
                    client = new Adult(clientName,id,income);
 

                if (client is Student && bank.GetType().Name != "BranchBank"
                    || client is Adult && bank.GetType().Name != "CentralBank") 
                {
                    return OutputMessages.UnsuitableBank;
                }

                bank.AddClient(client);
                return String.Format(OutputMessages.ClientAddedSuccessfully, clientTypeName, bankName);
            }

            return null;
        }

        public string FinalCalculation(string bankName)
        {
            IBank bank = banks.Models.FirstOrDefault(b => b.Name == bankName);

            if(bank != null)
            {
                double clientsIncome = bank.Clients.Sum(c => c.Income);
                double loansAmount = bank.Loans.Sum(c => c.Amount);

                double funds = clientsIncome + loansAmount;
                return String.Format(OutputMessages.BankFundsCalculated, bankName, $"{funds:F2}");
            }

            return null;
        }


        public string Statistics()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach(var bank in banks.Models)
            {
                stringBuilder.AppendLine(bank.GetStatistics());
            }

            return stringBuilder.ToString().Trim();
        }
    }
}
