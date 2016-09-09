using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonClasses
{
    public class Rnd
    {
		static Random random = new Random();
	    public static float Range(float min, float max)
	    {
		    float x = random.Next();
		    return (x/int.MaxValue)*(max - min) + min;
	    }

	    public static float Range(int min, int max)
	    {
		    return random.Next(min, max);
	    }
    }
}
