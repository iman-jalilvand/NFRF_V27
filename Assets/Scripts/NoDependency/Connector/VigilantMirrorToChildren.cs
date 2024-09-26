using UnityEngine;
using System.Collections;

public class VigilantMirrorToChildren : Base {
	public string incoming;

	private void Awake()
	{
		base.OnEnable();
		CacheMethod(incoming, Mirror);
	}

	protected override void OnEnable()
	{
		//
	}

	protected override void OnDisable()
	{
		//
	}

	private void OnDestroy()
	{
		base.OnDisable();
	}



	private void Mirror(object o)
	{
		foreach(Transform t in cachedTransform) {
			Call(incoming, t.gameObject, o);
		}
	}
	
}
