using UnityEngine;
using System.Collections;

public class ObjectLayerFilter : Base {
	[UnityEngine.Serialization.FormerlySerializedAs("mask")]
	public LayerMask Mask;
	[UnityEngine.Serialization.FormerlySerializedAs("incoming")]
	public string Incoming;
	// if you want other for those not qualify in list, just use one more. 
	[UnityEngine.Serialization.FormerlySerializedAs("outgoing")]
	public string Outgoing;

	private void Awake()
	{
		CacheMethod(Incoming, Filter);
	}

	private void Filter(object o)
	{
		GameObject other = o as GameObject;
		if(other == null) {
			return;
		}

		if(((1 << other.layer) & Mask.value) == 0) {
			// you are NOT included in layerMask. 
			return ;
		}
		// you are included in layerMask. 
		Call(Outgoing, cachedGameObject, o);

	}
}
