using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfHomes.Model
{
	public class AreaPrototype
	{
		public string Name;

		public ResourceStorage Production;

		public AreaPrototype(string name, Resource[] production)
		{
			Name = name;
			Production = new ResourceStorage(production);
		}
	}
}
