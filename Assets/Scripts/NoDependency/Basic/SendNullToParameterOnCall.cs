using UnityEngine;
using System.Collections;

public class SendNullToParameterOnCall : Base {
	public string Incoming;
	public string Outgoing;

	private void Awake()
	{
		CacheMethod(Incoming, (o)=> {
			Call(Outgoing, ExtractTarget(o));
		});
	}

	private GameObject ExtractTarget(object o)
	{
		GameObject result = null;

		if(o is GameObject) {
			result = o as GameObject;
		}

		// add more if you need more?

		return result;
	}
}
