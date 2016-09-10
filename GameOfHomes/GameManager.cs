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

		public GameEngine Engine;

		UserInputController menuInput,gameInput;

		UserInputController currentInput;

		bool exitFlag = false;

		FSA<States,string> fsa = new FSA<States, string>(States.Init); 
		 

		public void Init()
		{
			Engine = new GameEngine();
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
			gameInput.AddCommand(new UserCommand("look", "Look at location for more details",
				"OnOverview", Engine, new ArgumentSet(typeof(string))));
			gameInput.AddCommand(new UserCommand("turn", "Next turn",
				"OnTurn", Engine, null));

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
			Engine.CreateNewGame();
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
