using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonClasses;

namespace GameOfHomes.Model
{
	public class ResourceStorage : GeneralStorage<ResourcePrototype,Resource>
	{
		
		public ResourceStorage(Resource[] reslist)
		{
			if (reslist == null)
				return;
			foreach (var r in reslist)
			{
				this[r.Prototype] = r.Amount;
			}
		}

		public ResourceStorage()
		{
		}

		public ResourceStorage(GeneralStorage<ResourcePrototype, Resource> s) : base(s)
		{
		}

		public static ResourceStorage operator +
			(ResourceStorage r1, ResourceStorage r2)
		{
			ResourceStorage res = (ResourceStorage) r1.Clone();
			res.Append(r2);
			return res;
		}

		public static ResourceStorage operator *(ResourceStorage r1, float rate)
		{
			ResourceStorage res = (ResourceStorage) r1.Clone();
			res.Multiply(rate);
			return res;
		}

		protected override Resource CreateElement(ResourcePrototype key, float value)
		{
			return new Resource(key,value);
		}

		protected override float GetValue(Resource element)
		{
			return element.Amount;
		}

		protected override GeneralStorage<ResourcePrototype, Resource> Clone()
		{
			return new ResourceStorage(this);
		}
	}
}
