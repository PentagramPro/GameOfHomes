using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GameOfHomes.Commands;

namespace GameOfHomes
{
	public class UserInputController
	{
		

		Dictionary<string,UserCommand> commands = new Dictionary<string, UserCommand>();


		public void ProcessCommand()
		{
		
			try
			{
				string cmdLine = Console.ReadLine();

				cmdLine = cmdLine.Trim();
				int pos = cmdLine.IndexOf(' ');
				string cmd, args;
				if (pos >= 0)
				{
					cmd = cmdLine.Substring(0, pos);
					args = cmdLine.Substring(pos);
				}
				else
				{
					cmd = cmdLine;
					args = "";
				}


				if (!commands.ContainsKey(cmd))
					throw new ArgumentException("Unknown command: " + cmd);

				commands[cmd].Execute(args);
			}
			catch (ArgumentException ex)
			{
				Console.WriteLine(ex.Message);
	
			}
			catch (Exception ex)
			{
				Console.WriteLine("Cannot execute this command, unknown error");
			
			}

			
		}

		public void AddCommand(UserCommand command)
		{
			commands[command.Name] = command;
;
		}


		public override string ToString()
		{
			var sb = new StringBuilder();
			foreach (var key in commands.Keys)
			{
				sb.Append(" ");
				sb.Append(key);
				sb.Append(" - ");
				sb.AppendLine(commands[key].Description);
			}
			return sb.ToString();
		}
	}
}
