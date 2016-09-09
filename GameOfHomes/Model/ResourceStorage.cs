using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfHomes.Model
{
	public class ResourceStorage
	{
		Dictionary<ResourcePrototype,Resource> resources = new Dictionary<ResourcePrototype, Resource>(); 
		public float this[ResourcePrototype index]
		{
			get
			{
				if (!resources.ContainsKey(index))
					return 0;

				return resources[index].Amount;
			}
			set
			{
				resources[index] = new Resource(index,value);
			}
		}

		public ResourceStorage()
		{
		}

		public ResourceStorage(ResourceStorage s)
		{
			foreach (var key in s.resources.Keys)
			{
				resources[key] = s.resources[key];
			}
		}

		public ResourceStorage(Resource[] reslist)
		{
			if (reslist == null)
				return;
			foreach (var r in reslist)
			{
				resources[r.Prototype] = r;
			}
		}

		public void Clear() => resources.Clear();

		public static ResourceStorage operator+(ResourceStorage r1, ResourceStorage r2 )
		{
			ResourceStorage res = new ResourceStorage(r1);
			foreach (var key in r2.resources.Keys)
			{
				res[key] += r2[key];
			}
			return res;
		}

		public static ResourceStorage operator *(ResourceStorage r1, float rate)
		{
			ResourceStorage res = new ResourceStorage(r1);
			foreach (var k in res.resources.Keys)
			{
				res.resources[k].Amount *= rate;
			}
			return res;
		}
	}
}
