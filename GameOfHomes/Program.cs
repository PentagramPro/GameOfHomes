using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfHomes
{
	class Program
	{
		static void Main(string[] args)
		{

			GameManager _gameManager = new GameManager();

			_gameManager.Init();

			_gameManager.Start();
		}
	}
}
