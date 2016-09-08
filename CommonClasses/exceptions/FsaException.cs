using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonClasses.exceptions
{
	public class FsaException : Exception
	{
		public FsaException(string message) : base(message)
		{
		}
	}
}
