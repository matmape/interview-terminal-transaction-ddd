using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestion.Domain.Base
{
    public abstract class BaseEntity<T> where T:struct
    {
        public T Id { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
