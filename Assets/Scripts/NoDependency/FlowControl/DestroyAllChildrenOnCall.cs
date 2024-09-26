using UnityEngine;
using System.Collections;

public class DestroyAllChildrenOnCall : Base {
	public string Incoming;

	private void Awake()
	{
		CacheMethod(Incoming, DestroyAllChildren);
	}

	private void DestroyAllChildren(object o)
	{
		foreach(Transform child in cachedTransform)
		{
			Destroy(child.gameObject, 0);
		}
	}

}
