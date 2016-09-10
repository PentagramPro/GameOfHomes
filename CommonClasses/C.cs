using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonClasses
{
	public class C
	{
		static string space = "";

		static char opening = '<', closing = '>';

		static Dictionary<string,ConsoleColor> colors = new Dictionary<string, ConsoleColor>()
		{
			{"R",ConsoleColor.Red },
			{"Y",ConsoleColor.Yellow },
			{"G",ConsoleColor.Green },
			{"B",ConsoleColor.Blue },
			{"W",ConsoleColor.White },
			{"GR",ConsoleColor.Gray },
			{"DR",ConsoleColor.DarkRed },
			{"DY",ConsoleColor.DarkYellow },
			{"DG",ConsoleColor.DarkGreen },
			{"DB",ConsoleColor.DarkBlue },
		}; 
		public static void Inc()
		{
			space += " ";
		}

		public static void Dec()
		{
			if (space.Length == 0)
				return;
			space = space.Substring(1);
		}

		public static void W(string str)
		{
			Console.ResetColor();
			Console.Write(space+str);
		}

		public static void Wl()
		{
			Console.WriteLine();
		}
		public static void Wl(string str)
		{
			Console.ResetColor();
			Console.WriteLine(space+str);
		}

		// {R}Text{G}Othertext
		// R - red, Y - yellow, G - green, B - blue, W - white
		public static void InColor(string str)
		{
			Console.ResetColor();
			int pos = 0;
			while (true)
			{
				int br = str.IndexOf(opening,pos);
				if (br >= 0)
				{
					Console.Write(str.Substring(pos, br - pos));
				}
				else
				{
					Console.Write(str.Substring(pos));
					break;
				}

				pos = br+1;
				int cl = str.IndexOf(closing, pos, 3);
				if (cl >= 0)
				{
					string color = str.Substring(pos, cl - pos);
					SetColor(color);
					pos = cl + 1;
				}
				
			}
		}

		static void SetColor(string color)
		{
			if (!colors.ContainsKey(color))
				return;
			Console.ForegroundColor = colors[color];
		}
	}
}
