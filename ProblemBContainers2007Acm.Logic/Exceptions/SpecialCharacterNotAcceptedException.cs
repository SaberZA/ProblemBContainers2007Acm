using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemBContainers2007Acm.Test
{

    public class SpecialCharacterNotAcceptedException : Exception
    {
        public static string DisplayMessage => "Special Characters not Accepted";

        public SpecialCharacterNotAcceptedException() : base(DisplayMessage)
        {
        }
    }
    
}
