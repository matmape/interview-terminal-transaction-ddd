using InterviewQuestion.Domain.TerminalTransactions;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace InterviewQuestion
{
    public class TerminalTransactionData
    {
        public static List<TerminalTransaction> GetData()
        {
            try
            {
                var jsonData = File.ReadAllText("data.json");
                return JsonConvert.DeserializeObject<List<TerminalTransaction>>(jsonData);
            }
            catch (Exception)
            {
                return new List<TerminalTransaction>();
            }
        }
    }

    
}
