using UnityEngine;
using System.Collections;

public class SendFirstGameObjectInParameterOnCall : Base
{
	public string Incoming;
	public string Outgoing;

	private void Awake()
	{
		CacheMethod(Incoming, SendForEach);
	}

	private void SendForEach(object o)
	{
		IEnumerable objects = o as IEnumerable;
		if (objects != null)
		{
			foreach (object obj in objects)
			{
				if (obj is GameObject)
				{
					Call(Outgoing, cachedGameObject, (GameObject) obj);
					break;
				}
			}
		}
	}
}
