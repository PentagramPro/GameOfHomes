using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfHomes.Model;

namespace GameOfHomes
{
	public class GameEngine
	{
		World world;

		public void CreateNewGame()
		{
			world = World.GenerateWorld();
		}

		public void OnOverview(string what)
		{
			
		}

		public void Explore(int countyId)
		{

		}
	}
}
