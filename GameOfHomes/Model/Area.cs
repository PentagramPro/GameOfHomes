﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfHomes.Model
{
	public class Area
	{
		public float Space;
		public AreaPrototype Prototype;

		public Area(AreaPrototype prototype, float space)
		{
			Prototype = prototype;
			Space = space;
		}

		

	}
}
