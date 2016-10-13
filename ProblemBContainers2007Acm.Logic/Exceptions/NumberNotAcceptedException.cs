using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemBContainers2007Acm.Test
{

	public class NumberNotAcceptedException: Exception
    {
        public static string DisplayMessage => "Numbers not Accepted";

        public NumberNotAcceptedException() : base(DisplayMessage)
        {
        }
    }
}
