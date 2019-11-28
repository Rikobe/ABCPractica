using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTesting.Models
{
    public class Wrapper<T>
    {
        public bool Success { get; set; }
        public T Result { get; set; }
    }
}
