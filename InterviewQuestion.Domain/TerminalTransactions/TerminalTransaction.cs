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
        public string? GeoLocation { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public decimal Amount { get; set; }
        public string TerminalId { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Processor { get; set; }
        public decimal TmsAmount { get; set; }
        public decimal Surcharge { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
    }
}
