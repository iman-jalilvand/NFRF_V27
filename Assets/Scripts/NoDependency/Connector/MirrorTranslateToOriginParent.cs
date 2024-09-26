using UnityEngine;
using System.Collections;

public class MirrorTranslateToOriginParent : Base {
	public string Incoming;
	public string Outgoing;

	private void Awake()
	{
		CacheMethod(Incoming, Send);
	}

	private void Send(object o)
	{
		Call(Outgoing, cachedOriginTransform.parent.gameObject, o);
	}
}
