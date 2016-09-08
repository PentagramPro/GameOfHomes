using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfHomes.Commands;

namespace GameOfHomes
{
	public class Game
	{
		public GameEntryPoint GameEntry;

		UserInputController userInput;
		bool exitFlag = false;

		public void Init()
		{
			GameEntry = new GameEntryPoint(this);
			userInput = new UserInputController(GameEntry);

			userInput.AddCommand(new UserCommand("exit","Immediately closes the application","Exit",null));
		}

		public void Start()
		{
			while (exitFlag == false)
			{
				string cmdLine = Console.ReadLine();

				try
				{
					userInput.ProcessCommand(cmdLine);
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

		}

		public void ExitGame()
		{
			exitFlag = true;
		}
	}
}
