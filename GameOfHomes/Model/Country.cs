using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonClasses;
using GameOfHomes.Model.Technologies;
using GameOfHomes.Model.Technologies.Common;

namespace GameOfHomes.Model
{
	public class Country
	{
		public List<Area> Areas = new List<Area>();

		public Population Pop;


		public WorkTradition Tradition;
		public ResourceStorage OverallProduction;



		public static Country GenerateRandomCountry()
		{
			Country c = new Country();
			c.Tradition = new WorkTradition();


		}

		public void Turn()
		{
			CalculateProduction();

			Tradition.Turn(this);

			Pop.Turn();
		}


		void CalculateProduction()
		{
			OverallProduction.Clear();

			foreach (var area in Areas)
			{
				OverallProduction += area.Prototype.Production*area.Space;
			}
		}

	}
}
