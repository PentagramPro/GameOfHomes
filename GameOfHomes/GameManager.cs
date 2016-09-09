using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonClasses;
using GameOfHomes.Commands;

namespace GameOfHomes
{
	public class GameManager
	{
		enum States { Init, Menu,Game }

		public GameEngine GameEntry;

		UserInputController menuInput,gameInput;

		UserInputController currentInput;

		bool exitFlag = false;

		FSA<States,string> fsa = new FSA<States, string>(States.Init); 
		 

		public void Init()
		{
			GameEntry = new GameEngine(this);
			menuInput = new UserInputController();
			gameInput = new UserInputController();

			fsa.AddLink(States.Menu, States.Game, "new",OnNewGame);
			fsa.AddLink(States.Init, States.Menu, "init_complete",OnExitToMenu);

			var exitCommand = new UserCommand("exit", "Immediately closes the application",
				"OnExit", this, null);
			menuInput.AddCommand(exitCommand);
			gameInput.AddCommand(exitCommand);

			menuInput.AddCommand(new UserCommand("new", "Starts new game", 
				()=>fsa.Switch("new")));

			gameInput.AddCommand(new UserCommand("list", "Shows this list",
				OnPrintListOfCommands));
			
			fsa.Switch("init_complete");
			
		}

		public void Start()
		{
			while (exitFlag == false)
			{
				currentInput.ProcessCommand();
			}

		}

		void OnNewGame(States oldState, States newState)
		{
			currentInput = gameInput;
			Console.WriteLine("Welcome to the GameOfHomes! Type 'list' for a list of commands");
		}

		void OnExitToMenu(States oldState, States newState)
		{
			currentInput = menuInput;
			OnPrintListOfCommands();
		}

		void OnPrintListOfCommands()
		{
			Console.Write(currentInput.ToString());
		}

		public void OnExit()
		{
			exitFlag = true;
		}
	}
}
