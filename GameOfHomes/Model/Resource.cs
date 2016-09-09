using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfHomes.Model
{
	public class Resource
	{
		public ResourcePrototype Prototype;
		public float Amount;

		public Resource(ResourcePrototype prototype, float amount)
		{
			Prototype = prototype;
			Amount = amount;
		}
	}
}
