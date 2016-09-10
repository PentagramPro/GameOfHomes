using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonClasses;
using GameOfHomes.Model.Technologies.Common;

namespace GameOfHomes.Model
{
	public class World
	{
		public List<Country> Countries = new List<Country>();

		public static World GenerateWorld()
		{
			World res = new World();

			Country start = Country.GenerateRandomCountry(10);
			res.Countries.Add(start);

			return res;
		}

		public void Turn()
		{
			foreach (var country in Countries)
			{
				country.Turn();
			}
		}

		public void Overview()
		{
			C.Wl("Countries:");
			C.Inc();
			foreach (var country in Countries)
			{
				country.Overview();
			}
			C.Dec();
		}
	}
}
