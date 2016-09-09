using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonClasses;

namespace GameOfHomes.Model.Technologies
{
	public class AreaTransformTechnology
	{
		
		public AreaPrototype InputArea;
		public List<SubjectRate<AreaPrototype>> OutputArea;

		// per 1 sq km of input area
		public float Labour;
	}
}
