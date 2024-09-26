using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendBoolNotParameterOnCall : Base {
	public string Incoming;
	public string Outgoing;

	private void Awake()
	{
		CacheMethod(Incoming, Not);
	}

	private void Not(object o)
	{
		if(o == null) {
			return;
		}

		bool b;
		if(o is bool) {
			b = !(bool)o;
			Call(Outgoing, cachedGameObject, (bool) b);
		} else if(bool.TryParse(o.ToString(), out b)) {
			b = !b;
			Call(Outgoing, cachedGameObject, (bool) b);
		}
	}
}
