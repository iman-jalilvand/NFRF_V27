using UnityEngine;
using System.Collections;

public class MirrorTranslateFromOriginToSelf : Base {
	public string Incoming;
	public string Outgoing;

	private void Awake()
	{
        
		CacheMethod(Incoming, Send, cachedOriginGameObject);
	}

	private void Send(object o)
	{
		Call(Outgoing, cachedOriginGameObject, o);
	}
}
