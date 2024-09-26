using UnityEngine;
using System.Collections;

public class MirrorTranslateToParent : Base {
	[UnityEngine.Serialization.FormerlySerializedAs("incoming")]
	public string Incoming;
	[UnityEngine.Serialization.FormerlySerializedAs("outgoing")]
	public string Outgoing;

	private void Awake()
	{
		CacheMethod(Incoming, MirrorMethod);
	}

	private void MirrorMethod(object o)
	{
		Call(Outgoing, cachedTransform.parent.gameObject, o);
	}
}
