using UnityEngine;
using System.Collections;

public class SetChildOnCall : Base {
	public string Incoming;

	private void Awake()
	{
		CacheMethod(Incoming, SetChild);
	}

	private void SetChild(object o)
	{
		Transform target;
		if(o is GameObject) {
			o = ((GameObject)o).transform;
		}

		target = o as Transform;
		if(target) {
			target.parent = cachedTransform;
		}
	}
}
