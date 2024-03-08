﻿namespace BankLoan.Models
{
    public class CentralBank : Bank
    {
        private const int capacityDefault = 50;
        public CentralBank(string name) 
            : base(name, capacityDefault)
        {
        }
    }
}
