using InterviewQuestion.Domain.Entities;
using InterviewQuestion.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestion.Infrastructure.Data.Repositories
{
    public interface IAgentRepository:IRepositoryAsync<Agent>
    {

    }
    public class AgentRepository : RepositoryAsync<Agent>, IAgentRepository
    {
        public AgentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
