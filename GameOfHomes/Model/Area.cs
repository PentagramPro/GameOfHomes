using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonClasses;

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


		public void Overview()
		{
			C.W(Prototype.Name+" : ");
			foreach (var p in Prototype.Production)
			{
				C.InColor($"<G>{p.Amount} <W>{p.Prototype.Name}  ");
			}
			C.Wl();

		}
	}
}
