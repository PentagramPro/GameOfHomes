using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfHomes.Commands
{
	public class ArgumentSet
	{
		Dictionary<Type, Func<string, object>> parsers = new Dictionary<Type, Func<string,object>>()
		{
			{
				typeof(int), s => int.Parse(s)
			},
			{
				typeof(string),s=>s
			},
			{
				typeof(float),s=>float.Parse(s,NumberStyles.Any)
			}
		};

		List<Type> argumentTypes = new List<Type>();


		public ArgumentSet(params Type[] argumentTypes)
		{
			this.argumentTypes.AddRange(argumentTypes);
		}


		public object[] ParseArguments(string args)
		{
			if (string.IsNullOrEmpty(args))
				return null;

			string[] strArgsArray = args.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
			
			if(strArgsArray.Length!=argumentTypes.Count)
				throw new ArgumentException("Wrong number of arguments");

			object[] res = new object[argumentTypes.Count];

			return argumentTypes.Select((t, i) => parsers[t].Invoke(strArgsArray[i])).ToArray();
			/*int i = 0;
			foreach (var type in argumentTypes)
			{
				res[i] = parsers[type].Invoke(strArgsArray[i]);
				i++;
			}
			*/
		}
	}
}
