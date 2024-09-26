using UnityEngine;
using System.Collections;

public class SendSelfGameObjectToParameterOnCall : Base {
	public string Incoming;
	public string Outgoing;

	private void Awake()
	{
		CacheMethod(Incoming, Send);
	}

	private void Send(object o)
	{
		Call(Outgoing, o as GameObject, cachedGameObject);
	}
}
