using UnityEngine;
using System.Collections;

public class DisableColliderOnCall : Base {
	[UnityEngine.Serialization.FormerlySerializedAs("target")]
	public Collider Target;
	[UnityEngine.Serialization.FormerlySerializedAs("callDisable")]
	public string CallDisable;

	private void Start()
	{
		CacheMethod(CallDisable, Disable);
	}

	private void Disable(object o)
	{
		Target.enabled = false;
	}
}
