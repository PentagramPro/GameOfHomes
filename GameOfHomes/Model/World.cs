using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfHomes.Model.Technologies.Common;

namespace GameOfHomes.Model
{
	public class World
	{
		public List<Country> Countries = new List<Country>(); 

		public List<IAreaTechnology> AreaTechs = new List<IAreaTechnology>(); 
	}
}
