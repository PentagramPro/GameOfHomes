using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GameOfHomes.Commands
{
	public class UserCommand
	{
		public string Name;
		public string Description;
		public string Method;

		MethodInfo callableMethod;
		object callableObject;

		ArgumentSet arguments;
		 

		public UserCommand(string name, string description, string method, ArgumentSet arguments)
		{
			Name = name;
			Description = description;
			Method = method;
			this.arguments = arguments;
		}

		public void InitCommand(MethodInfo method, object o)
		{
			callableMethod = method;
			callableObject = o;
		}

		public void Execute(string args)
		{
			object[] o = arguments?.ParseArguments(args);

			callableMethod.Invoke(callableObject, o);
		}
	}
}
