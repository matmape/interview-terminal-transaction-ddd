using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestion.Domain.Shared
{
    public class PagedList<T> where T:class
    {
        public List<T> Items { get; set; }
        public int Total { get; set; }
    }
}
