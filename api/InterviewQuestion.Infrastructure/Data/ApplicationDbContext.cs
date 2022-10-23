using InterviewQuestion.Domain.TerminalTransactions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestion.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<TerminalTransaction> TerminalTransactions { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
