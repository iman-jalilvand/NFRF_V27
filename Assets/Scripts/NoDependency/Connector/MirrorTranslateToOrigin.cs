using UnityEngine;
using System.Collections;

public class MirrorTranslateToOrigin : Base {
	public string Incoming;
	public string Outgoing;

	private void Awake()
	{
		CacheMethod(Incoming, Send);
	}

	private void Send(object o)
	{
		Call(Outgoing, cachedOriginGameObject, o);
	}
}
