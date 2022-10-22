using InterviewQuestion.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestion.Domain.TerminalTransactions
{
    public class TerminalTransaction:BaseEntity<int>
    {
        public string TransactionReference { get; set; }
        public string CurrencyCode { get; set; }
        public string AgentName { get; set; }
        public string GeoLocation { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public double Amount { get; set; }
        public string TerminalId { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Processor { get; set; }
        public double TmsAmount { get; set; }
        public double Surcharge { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
    }
}
