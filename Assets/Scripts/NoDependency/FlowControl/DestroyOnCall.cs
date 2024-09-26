using UnityEngine;
using System.Collections;

public class DestroyOnCall : Base {
	public string Incoming;

	private void Awake()
	{
		CacheMethod(Incoming, Kill);
	}

	private void Kill(object o)
	{
		Destroy(cachedGameObject, 0);
	}
}
