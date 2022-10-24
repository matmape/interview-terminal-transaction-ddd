using InterviewQuestion.Domain.Base;
using InterviewQuestion.Domain.TerminalTransactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestion.Domain.Entities
{
    public class Agent:BaseEntity<int>
    {
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
        private Agent() { }
        public Agent(string name, string phone)
        {
            Name = name;
            PhoneNumber = phone;
        }
        public void Update(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }
        public ICollection<TerminalTransaction> TerminalTransactions { get; } = new List<TerminalTransaction>();

        public void AddTerminalTransaction(string terminalId,
            string processor,
            string transactionReference,
            string responseCode,
            string responseMessage,
            string currencyCode,
            decimal tmsAmount,
            decimal surcharge) => this.TerminalTransactions.Add(new TerminalTransaction(terminalId,
                processor,
                transactionReference,
                responseCode,
                responseMessage,
                currencyCode,
                Name,
                "0,0",
                tmsAmount,
                surcharge
                ));
    }
}
