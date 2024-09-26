using UnityEngine;
using System.Collections;

public class DestroyOriginOnCall : Base {
	public string Incoming;

	private void Awake()
	{
		CacheMethod(Incoming, KillOrigin);
	}

	private void KillOrigin(object o)
	{
		Destroy(cachedOriginGameObject, 0);
	}
}
