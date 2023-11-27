using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.ProblemDomain
{
    public class Node
    {
        public User Value { get; set; }
        public Node Next { get; set; }

        public Node(User value)
        {
            Value = value;
            Next = null;
        }
    }
}
