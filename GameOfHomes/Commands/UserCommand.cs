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

		Action callableAction;

		ArgumentSet arguments;


		public UserCommand(string name, string description, Action action)
		{
			callableAction = action;
			Name = name;
			Description = description;
		}

		public UserCommand(string name, string description, string method, object obj, ArgumentSet arguments)
		{
			Name = name;
			Description = description;
			Method = method;
			callableObject = obj;


			callableMethod = obj.GetType().GetMethod(method);

			if (callableMethod == null)
				throw new ArgumentException("Method " + method + " does not exist");

			this.arguments = arguments;
		}


		public void Execute(string args)
		{
			object[] o = arguments?.ParseArguments(args);

			callableMethod?.Invoke(callableObject, o);
			callableAction?.Invoke();
		}
	}
}
