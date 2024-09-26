using UnityEngine;
using System.Collections;

public class DisableScriptOnCall : Base {
	[UnityEngine.Serialization.FormerlySerializedAs("target")]
	public MonoBehaviour Target;
	[UnityEngine.Serialization.FormerlySerializedAs("callDisable")]
	public string CallDisable;

	private void Awake()
	{
        UpdateCachedFields();
		CacheMethod(CallDisable, Disable);
	}

	private void Disable(object o)
	{
		Target.enabled = false;
	}
}
