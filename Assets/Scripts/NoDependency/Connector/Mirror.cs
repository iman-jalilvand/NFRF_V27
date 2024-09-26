using UnityEngine;
using System.Collections;

public class Mirror : Base {
	[UnityEngine.Serialization.FormerlySerializedAs("msg")]
	public string Incoming;
	[UnityEngine.Serialization.FormerlySerializedAs("callSetTarget")]
	public string CallSetTarget;
	[UnityEngine.Serialization.FormerlySerializedAs("target")]
	public GameObject Target;


	private void SetTarget(object o) {
		if(Target != cachedGameObject) {
			Target = o as GameObject;
		}
	}

	private void Awake()
	{
		CacheMethod(CallSetTarget, SetTarget);
		CacheMethod(Incoming, (o) =>
		{
			if(Target == null) {
				return;
			}
			Call(Incoming, Target, o);
		});
	}
}
