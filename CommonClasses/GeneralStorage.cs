using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonClasses
{
	public abstract class GeneralStorage<TKey,TElement> : IEnumerable<TElement> where TElement : class 
	{
		Dictionary<TKey, TElement> resources = new Dictionary<TKey, TElement>();
		public float this[TKey index]
		{
			get
			{
				if (!resources.ContainsKey(index))
					return 0;

				return  GetValue(resources[index]);
			}
			set
			{
				resources[index] = CreateElement(index,value);
			}
		}

		public GeneralStorage()
		{
		}

		public GeneralStorage(GeneralStorage<TKey,TElement> s)
		{
			foreach (var key in s.resources.Keys)
			{
				this[key] = s[key];
			}
		}

		

		public void Clear() => resources.Clear();

		

		public void Append(GeneralStorage<TKey, TElement> r2)
		{
			foreach (var key in r2.resources.Keys)
			{
				this[key] += r2[key];
			}
		}

		public void Multiply(float rate)
		{
			foreach (var k in resources.Keys)
			{
				this[k] *= rate;
			}
		}

		public TElement GetElement(TKey prot)
		{
			TElement res = null;
			resources.TryGetValue(prot, out res);
			return res;
		}

		
		protected abstract TElement CreateElement(TKey key,float value);
		protected abstract float GetValue(TElement element);
		protected abstract GeneralStorage<TKey, TElement> Clone();
		public IEnumerator<TElement> GetEnumerator()
		{
			return resources.Values.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
