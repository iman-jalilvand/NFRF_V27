using UnityEngine;
using System.Collections;

public class SelfColliderInterface : Base {
	private Collider c;
	public Collider SelfCollider {
		get {
			if(c == null) {
				c = cachedGameObject.GetComponent<Collider>();
			}

			return c;
		}
	}

	public string CallEnable;
	public string CallDisable;

	private void Awake()
	{
		CacheMethod(CallEnable, Enable);
		CacheMethod(CallDisable, Disable);
	}

	private void Enable(object o)
	{
		Collider selfCollider = SelfCollider;
		if(selfCollider != null) {
			selfCollider.enabled = true;
		}
	}

	private void Disable(object o)
	{
		Collider selfCollider = SelfCollider;
		if(selfCollider != null) {
			selfCollider.enabled =false;
		}
	}
}
