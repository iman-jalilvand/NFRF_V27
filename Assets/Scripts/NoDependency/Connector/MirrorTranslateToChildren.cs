using UnityEngine;
using System.Collections;

public class MirrorTranslateToChildren : Base {
	public string Incoming;
	public string Outgoing;

	private void Awake()
	{
		CacheMethod(Incoming, Send);
	}

	private void Send(object o)
	{
		foreach(Transform t in cachedTransform) {
			Call(Outgoing, t.gameObject, o);
		}
	}
}
