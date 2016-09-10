using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfHomes.Model.Technologies
{
	public class WorkTradition
	{
		public float WoodToTownArea = 10;
		 
		public void Turn(Country targetCountry)
		{
			float freeHouses = targetCountry.OverallProduction[Resources.Housing] - targetCountry.Pop.Total;
			if (freeHouses<0)
			{
				targetCountry.WriteLog("Not enough houses, building more");

				float addSquare = -freeHouses/AreasDic.Town.Production[Resources.Housing];

				float afterAreaCheck = Math.Min(targetCountry.Areas[AreasDic.Wasteland], addSquare);
				if(afterAreaCheck<addSquare)
					targetCountry.WriteLog("Not enough wastelands to convert to town");

				float afterResCheck = Math.Min(targetCountry.OverallProduction[Resources.Wood]
					/WoodToTownArea, afterAreaCheck);

				if (afterResCheck < afterAreaCheck)
					targetCountry.WriteLog("Not enough wood to build town");

				if (afterResCheck > 0)
				{
					targetCountry.WriteLog($"Building {afterResCheck} sq km of town");
					targetCountry.Areas[AreasDic.Wasteland] -= afterResCheck;
				}
			}
		}
	}
}
