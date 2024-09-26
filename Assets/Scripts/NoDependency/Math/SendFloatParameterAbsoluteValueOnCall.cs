using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendFloatParameterAbsoluteValueOnCall : Base {
	public string Incoming;
	public string Outgoing;

	private void Awake()
	{
		CacheMethod(Incoming, Abs);
	}

	private void Abs(object o)
	{
		float f;
		if(float.TryParse(o.ToString(), out f)) {
			Call(Outgoing, cachedGameObject, Mathf.Abs(f));
		}
	}
}
