using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestion.Domain.Shared
{
    public enum ResultType
    {
        Success = 1,
        Error = 2,
        ValidationError = 3,
        Warning = 4,
        Empty = 6
    }
}
