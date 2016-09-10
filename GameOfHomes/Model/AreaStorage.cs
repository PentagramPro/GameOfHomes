using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonClasses;

namespace GameOfHomes.Model
{
	public class AreaStorage : GeneralStorage<AreaPrototype,Area>
	{
		public AreaStorage()
		{
		}

		public AreaStorage(GeneralStorage<AreaPrototype, Area> s) : base(s)
		{
		}

		protected override Area CreateElement(AreaPrototype key, float value)
		{
			return new Area(key,value);
		}

		protected override float GetValue(Area element)
		{
			return element.Space;
		}

		protected override GeneralStorage<AreaPrototype, Area> Clone()
		{
			return new AreaStorage(this);
		}
	}
}
