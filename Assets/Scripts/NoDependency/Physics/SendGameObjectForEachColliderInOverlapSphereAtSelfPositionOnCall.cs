using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendGameObjectForEachColliderInOverlapSphereAtSelfPositionOnCall : Base {
	public float radius;
	public LayerMask mask;

	public string CallOverlapSphere;
	public string Outgoing;

	private void Awake()
	{
		CacheMethod(CallOverlapSphere, OverlapSphere);
	}

	private void OverlapSphere(object o)
	{
		Collider[] cs = Physics.OverlapSphere(cachedTransform.position, radius, mask.value);
		for(int i = 0, max = cs.Length; i < max; ++i) {
			Call(Outgoing, cachedGameObject, cs[i].gameObject);
		}
	}
}
