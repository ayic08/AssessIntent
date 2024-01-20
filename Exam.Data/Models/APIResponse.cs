using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Data.Models
{
    public class APIResponse<T>
    {
        public bool Success { get; set; }  
        public T? Result { get; set; }
    }
}
