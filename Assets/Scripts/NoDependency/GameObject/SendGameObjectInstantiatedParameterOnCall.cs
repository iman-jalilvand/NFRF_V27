using UnityEngine;
using System.Collections;

public class SendGameObjectInstantiatedParameterOnCall : Base {
	public string Incoming;
	public string Outgoing;

	private void Awake()
	{
		CacheMethod(Incoming, Send);
	}

	private void Send(object o)
	{
		GameObject instantiated = GameObject.Instantiate(ExtractGameObject(o));
		Call(Outgoing, cachedGameObject, instantiated);
	}

	private GameObject ExtractGameObject(object o)
	{
		GameObject result = null;

		if(o is GameObject)
		{
			result = o as GameObject;
		}

		return result;
	}
}
