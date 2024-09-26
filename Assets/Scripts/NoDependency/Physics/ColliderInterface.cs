using UnityEngine;
using System.Collections;

public class ColliderInterface : Base {
	public Collider Target;
	public string CallEnable;
	public string CallDisable;

	private void Awake()
	{
		CacheMethod(CallEnable, Enable);
		CacheMethod(CallDisable, Disable);
	}

	private void Enable(object o)
	{
		Target.enabled = true;
	}

	private void Disable(object o)
	{
		Target.enabled =false;
	}
}
