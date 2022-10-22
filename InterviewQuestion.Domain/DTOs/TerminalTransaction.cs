using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestion.Domain.DTOs
{
    public class TerminalTransactionDto
    {
        public int Id { get; set; }
        public string TransactionReference { get; set; }
        public string CurrencyCode { get; set; }
        public string AgentName { get; set; }
        public string? GeoLocation { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public double Amount { get; set; }
        public string TerminalId { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Processor { get; set; }
        public double TmsAmount { get; set; }
        public double Surcharge { get; set; }
    }
    public class TerminalTransactionItem : TerminalTransactionDto
    {
        public DateTime DateCreated { get; set; }
    }
    public class TerminalTransactionFilter : TerminalTransactionItem
    {
        public DateTime? DateCreatedFrom { get; set; }
        public DateTime? DateCreatedTo { get; set; }
        public static TerminalTransactionFilter Deserialize(string wherecondition)
        {
            if (string.IsNullOrEmpty(wherecondition)) return new TerminalTransactionFilter();
            return JsonConvert.DeserializeObject<TerminalTransactionFilter>(wherecondition);
        }
    }
}
