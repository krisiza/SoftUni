using BankLoan.Models.Contracts;
using BankLoan.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankLoan.Models
{
    public abstract class Bank : IBank
    {
        private string name;
        private List<ILoan> loans;
        private List<IClient> clients;

        public Bank(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;

            loans = new List<ILoan>();
            clients = new List<IClient>();
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BankNameNullOrWhiteSpace);
                }

                name = value;
            }
        }

        public int Capacity { get; private set; }

        public IReadOnlyCollection<ILoan> Loans => loans.AsReadOnly();

        public IReadOnlyCollection<IClient> Clients => clients.AsReadOnly();

        public double SumRates() => loans.Sum(l => l.InterestRate);

        public void AddClient(IClient Client)
        {
            if (clients.Count < Capacity)
            {
                clients.Add(Client);
            }
            else
                throw new ArgumentException(ExceptionMessages.NotEnoughCapacity);
        }

        public void RemoveClient(IClient Client) => clients.Remove(Client);

        public void AddLoan(ILoan loan) => loans.Add(loan);

        public string GetStatistics()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Name: {Name}, Type: {this.GetType().Name}");

            if (clients.Count == 0)
                stringBuilder.AppendLine("Clients: none");
            else
            {
                List<string> clientsNames = clients.Select(c => c.Name).ToList();
                stringBuilder.AppendLine($"Clients: {string.Join(", ", clientsNames)}");
            }

            stringBuilder.AppendLine($"Loans: {loans.Count}, Sum of Rates: {SumRates()}");

            return stringBuilder.ToString().Trim();
        }
    }
}
