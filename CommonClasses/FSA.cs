using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonClasses.exceptions;

namespace CommonClasses
{
	public class FSA<TState, TEvent> 
	{

		class FSALink
		{
			public TState From, To;
			public TEvent Event;
			public Action<TState, TState> Action;
		}

		List<FSALink> links = new List<FSALink>();

		TState currentState;

		public FSA(TState initialState)
		{
			currentState = initialState;
		}   

		public void AddLink(TState from, TState to, TEvent ev, Action<TState, TState> action)
		{
			links.Add(new FSALink {From = from,To=to,Event=ev,Action=action});
		}

		public void Switch(TEvent ev)
		{
			var link = links.Find(i => i.Event.Equals(ev) && i.From.Equals(currentState));
			if (link == null)
				return;
			link.Action(currentState, link.To);
			currentState = link.To;
		}
	}

}
