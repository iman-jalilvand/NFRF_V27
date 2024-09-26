using UnityEngine;
using System.Collections;

public class SendGameObjectForEachGameObjectInParameterOnCall : Base
{
	public string Incoming;
	public string Outgoing;
    public string OutgoingOnFinish;

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
					Send((GameObject)obj);
				}
			}
            Call(OutgoingOnFinish, cachedGameObject);
		}
	}

	private void Send(GameObject go)
	{
		Call(Outgoing, cachedGameObject, go);
	}
}
