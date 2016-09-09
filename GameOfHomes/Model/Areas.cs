﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfHomes.Model
{
	public class Areas
	{
		public static readonly AreaPrototype 
			Farmland = new AreaPrototype("farmland",new []
			{
				new Resource(Resources.Food,10)
			}),
			Wasteland = new AreaPrototype("wasteland",null),
			Forest = new AreaPrototype("forest", new[]
			{
				new Resource(Resources.Food,2)
			}),
			Town = new AreaPrototype("town", new[]
			{
				new Resource(Resources.Food,0.5f),
				new Resource(Resources.Housing,100), 
			});
		
	}
}
