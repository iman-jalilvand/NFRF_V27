using UnityEngine;
using System.Collections;

public class EnableColliderOnCall : Base {
	[UnityEngine.Serialization.FormerlySerializedAs("target")]
	public Collider Target;
	[UnityEngine.Serialization.FormerlySerializedAs("callDisable")]
	public string CallDisable;

	private void Start()
	{
		CacheMethod(CallDisable, Enable);
	}

	private void Enable(object o)
	{
		Target.enabled = true;
	}
}
