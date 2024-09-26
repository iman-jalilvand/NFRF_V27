using UnityEngine;
using System.Collections;

public class DisableGameObjectOnCall : Base {
	[UnityEngine.Serialization.FormerlySerializedAs("target")]
	public GameObject Target;
	[UnityEngine.Serialization.FormerlySerializedAs("callDisable")]
	public string CallDisable;

	private void Awake()
	{
		CacheMethod(CallDisable, Disable);
	}

	private void Disable(object o)
	{
		if (Target != null) {
			Target.SetActive (false);
		}
	}
}
