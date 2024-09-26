using UnityEngine;
using System.Collections;

public class MirrorToChildren : Base {
	public string incoming;

	private void Awake()
	{
		CacheMethod(incoming, Mirror);
	}

	private void Mirror(object o)
	{
		foreach(Transform t in cachedTransform) {
			Call(incoming, t.gameObject, o);
		}
	}
	
}
