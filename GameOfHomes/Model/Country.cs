using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfHomes.Model
{
	public class Country
	{
		public List<Area> Areas = new List<Area>();

		public Population Pop;

		public float FoodProduction { get; private set; }

		public Country()
		{
			CalculateStats();
		}

		void CalculateStats()
		{
			foreach (var area in Areas)
			{
				FoodProduction += area.FoodProduction;
			}
		}

	}
}
