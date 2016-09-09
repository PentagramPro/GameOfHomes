using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfHomes.Model
{
	public class ResourcePrototype
	{
		public string Name;
		public string Description;

		public ResourcePrototype(string name, string description)
		{
			Name = name;
			Description = description;
		}
	}
}
