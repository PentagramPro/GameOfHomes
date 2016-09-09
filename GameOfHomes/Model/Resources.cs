using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfHomes.Model
{
	public class Resources
	{
		public static readonly ResourcePrototype 
			Food = new ResourcePrototype("food",""),
			Housing = new ResourcePrototype("housing",""),
			Wood = new ResourcePrototype("wood","");

	}
}
