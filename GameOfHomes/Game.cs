using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonClasses;
using GameOfHomes.Commands;

namespace GameOfHomes
{
	public class Game
	{
		enum States { Menu,Game }

		public GameEntryPoint GameEntry;

		UserInputController userInput;
		bool exitFlag = false;

		FSA<States,string> fsa = new FSA<States, string>(States.Menu); 
		 

		public void Init()
		{
			GameEntry = new GameEntryPoint(this);
			userInput = new UserInputController(GameEntry);

			fsa.AddLink(States.Menu, States.Game, "new",OnNewGame);

			userInput.AddCommand(new UserCommand("exit","Immediately closes the application",
				"OnExit",this,null));
			userInput.AddCommand(new UserCommand("new", "Starts new game", 
				()=>fsa.Switch("new")));
		}

		public void Start()
		{
			while (exitFlag == false)
			{
				userInput.ProcessCommand();
			}

		}

		void OnNewGame(States oldState, States newState)
		{
			
		}

		public void OnExit()
		{
			exitFlag = true;
		}
	}
}
