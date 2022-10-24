namespace InterviewQuestion.API.DTOs
{
    public class AgentCreateDto
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
    public class AgentDto
    {
        public int AgentId { get; set; }
        public string Name { get;  set; }
        public string PhoneNumber { get;  set; }
    }

    public class AgentItem
    {

    }
    public class AgentUpdateDto
    {
        public int Id { get; set; }
        public string Name { get;  set; }
        public string PhoneNumber { get;  set; }
    }
    public class AgentUpdateResponse
    {
        public int Id { get; set; }
    }
    public class AgentDeleteDto
    {
        public string Message { get;  set; }
    }
}
