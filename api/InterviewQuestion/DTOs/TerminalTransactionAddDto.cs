namespace InterviewQuestion.API.DTOs
{
    public class TerminalTransactionAddDto
    {
        public string TransactionReference { get; set; }
        public string CurrencyCode => "NGN";
        public string AgentName { get; set; }
        public string? GeoLocation = "3.5,3.7";
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public double Amount { get; set; }
        public string Processor { get; set; }
        public string TerminalId { get; set; }
        public double Surcharge => 10.75;
    }
    public class TerminalTransactionAddToAgentDto
    {
        public string TransactionReference { get; set; }
        public string AgentName { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public decimal Amount { get; set; }
        public string Processor { get; set; }
        public string TerminalId { get; set; }
        public int AgentId { get;  set; }
    }
    public class TerminalTransactionUpdateDto
    {
        public int Id { get; set; }
        public string TransactionReference { get; set; }
        public string AgentName { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public double Amount { get; set; }
        public string Processor { get; set; }
    }
}
