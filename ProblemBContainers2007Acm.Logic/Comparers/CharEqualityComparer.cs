using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ProblemBContainers2007Acm.Test
{

	public class CharEqualityComparer : IEqualityComparer<char>
	{
		public bool Equals(char x, char y)
		{
			return x.Equals(y);
		}

		public int GetHashCode(char obj)
		{
			var hashProductName = obj.GetHashCode();

			return hashProductName;
		}
	}
}
