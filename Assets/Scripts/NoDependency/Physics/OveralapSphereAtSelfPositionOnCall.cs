using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OveralapSphereAtSelfPositionOnCall : Base {
	public float radius;
	public LayerMask mask;

	public string CallOverlapSphere;
	
	private void Awake()
	{
		CacheMethod(CallOverlapSphere, OverlapSphere);
	}

	private void OverlapSphere(object o)
	{
		Physics.OverlapSphere(cachedTransform.position, radius, mask.value);
	}
}
