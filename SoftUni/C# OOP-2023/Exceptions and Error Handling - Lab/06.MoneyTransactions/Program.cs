using System.Runtime.CompilerServices;

namespace _06.MoneyTransactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArgumentException invalidCommand = new ArgumentException("Invalid command!");
            ArgumentException invalidAccount = new ArgumentException("Invalid account!");
            ArgumentException insufficientBalance = new ArgumentException("Insufficient balance!");

            Dictionary<int, decimal> bankAccounts = new Dictionary<int, decimal>();

            string[] tokens = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries);

            string[] bankInfo = null;

            foreach (string token in tokens)
            {
                bankInfo = token.Split("-");

                int accountNumber = int.Parse(bankInfo[0]);
                decimal balance = decimal.Parse(bankInfo[1]);

                if (!bankAccounts.ContainsKey(accountNumber))
                {
                    bankAccounts.Add(accountNumber, balance);
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    CheckCommand(commands[0], invalidCommand);

                    if (commands[0] == "Deposit")
                    {
                        DepositSum(invalidAccount, bankAccounts, commands);
                        Console.WriteLine($"Account {commands[1]} has new balance: {bankAccounts[int.Parse(commands[1])]:f2}");
                    }
                    else if (commands[0] == "Withdraw")
                    {
                        WithdrawSum(invalidAccount, insufficientBalance, bankAccounts, commands);
                        Console.WriteLine($"Account {commands[1]} has new balance: {bankAccounts[int.Parse(commands[1])]:f2}");
                    }
                }
                catch(ArgumentException ex) 
                {
                    Console.WriteLine(ex.Message);
                }
                
                Console.WriteLine("Enter another command");
            }
        }

        private static void CheckCommand(string command, ArgumentException invalidCommand)
        {
            if (command != "Deposit" && command != "Withdraw")
                throw invalidCommand;
        }

        private static void WithdrawSum(ArgumentException invalidAccount, ArgumentException insufficientBalance, Dictionary<int, decimal> bankAccounts, string[] commands)
        {
            int accountNumber = int.Parse(commands[1]);
            if (!bankAccounts.ContainsKey(accountNumber))
            {
                throw invalidAccount;
            }

            decimal sum = decimal.Parse(commands[2]);

            if (sum > bankAccounts[accountNumber])
            {
                throw insufficientBalance;
            }

            bankAccounts[accountNumber] -= sum;
        }

        private static void DepositSum(ArgumentException invalidAccount, Dictionary<int, decimal> bankAccounts, string[] commands)
        {
            int accountNumber = int.Parse(commands[1]);
            if (!bankAccounts.ContainsKey(accountNumber))
            {
                throw invalidAccount;
            }

            decimal sum = decimal.Parse(commands[2]);

            bankAccounts[accountNumber] += sum;
        }
    }
}