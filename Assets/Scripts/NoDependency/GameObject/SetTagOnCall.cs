using UnityEngine;
using System.Collections;

public class SetTagOnCall : Base {
	public string Incoming;

	private void Awake()
	{
		CacheMethod(Incoming, SetTag);
	}

	private void SetTag(object o)
	{
		cachedGameObject.tag = o.ToString();
	}
}
