using UnityEngine;
using System.Collections;

public class SetActiveGameObjectOnCall : Base {
	[UnityEngine.Serialization.FormerlySerializedAs("target")]
	public GameObject Target;
	[UnityEngine.Serialization.FormerlySerializedAs("callEnable")]
	public string CallEnable;
	[UnityEngine.Serialization.FormerlySerializedAs("callDisable")]
	public string CallDisable;
	[UnityEngine.Serialization.FormerlySerializedAs("callSetActive")]
	public string CallSetActive;

	private void Awake()
	{
		CacheMethod(CallEnable, Enable);
		CacheMethod(CallDisable, Disable);
		CacheMethod(CallSetActive, SetActive);
	}

	private void Enable(object o)
	{
		if(Target == null) {
			return;
		}
		Target.SetActive(true);
	}

	private void Disable(object o)
	{
        if (Target == null) {
			return;
		}
		Target.SetActive(false);
	}

	private void SetActive(object o)
	{
		if(Target == null) {
			return;
		}
		if(o is string) {
			o = bool.Parse((string)o);
		}

		if(o is bool) {
			Target.SetActive((bool) o);
		}

	}
}
