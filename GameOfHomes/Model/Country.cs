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
		public AreaStorage Areas = new AreaStorage();

		public Population Pop;


		public WorkTradition Tradition;
		public ResourceStorage OverallProduction;

		public List<string> TurnLog = new List<string>(); 

		public static Country GenerateRandomCountry(float pop)
		{
			Country c = new Country();
			c.Tradition = new WorkTradition();
			c.Pop = new Population(c,pop);

			c.Areas[Model.AreasDic.Forest] = Rnd.Range(3.0f, 5.0f);
			c.Areas[Model.AreasDic.Farmland] = Rnd.Range(1.0f, 4.0f);
			c.Areas[Model.AreasDic.Wasteland] = Rnd.Range(0.1f, 2.0f);

			return c;
		}

		public void Turn()
		{
			TurnLog.Clear();

			CalculateProduction();

			Tradition.Turn(this);

			Pop.Turn();
		}

		public void WriteLog(string s)
		{
			TurnLog.Add(s);
		}

		void CalculateProduction()
		{
			OverallProduction.Clear();

			foreach (var area in Areas)
			{
				OverallProduction += area.Prototype.Production*area.Space;
			}
		}

		public void Overview()
		{
			
			C.Wl("Areas:");
			C.Inc();
			foreach (var area in Areas)
			{
				area.Overview();
			}
			C.Dec();

		}

	}
}
