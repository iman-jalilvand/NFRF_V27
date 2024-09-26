using UnityEngine;
using System.Collections;

public class EnableScriptOnCall : Base {
	[UnityEngine.Serialization.FormerlySerializedAs("target")]
	public MonoBehaviour Target;
	[UnityEngine.Serialization.FormerlySerializedAs("callDisable")]
	[UnityEngine.Serialization.FormerlySerializedAs("CallEnable")]
	public string CallEnable;

	private void Awake()
	{
        UpdateCachedFields();
		CacheMethod(CallEnable, Enable);
	}

	private void Enable(object o)
	{
		Target.enabled = true;
	}
}
