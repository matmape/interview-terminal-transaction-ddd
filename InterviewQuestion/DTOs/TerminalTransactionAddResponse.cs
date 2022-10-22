namespace InterviewQuestion.API.DTOs
{
    public class TerminalTransactionAddResponse
    {
        public string Message { get; set; }
    }
    public class TerminalTransactionUpdateResponse
    {
        public int Id { get; set; }
        public string Message { get; set; }
    }
    public class TerminalTransactionDeleteResponse
    {
        public string Message { get; set; }
    }
    public class DashboardModel
    {
        public decimal TransactionVolume { get; set; }
        public decimal UserCount { get; set; }
        public decimal StockCount { get; set; }
        public decimal WithdrawalCount { get; set; }
    }
}
