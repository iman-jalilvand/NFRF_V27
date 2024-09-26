using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OveralapSphereOnCall : Base {
	public Vector3 position;
	public float radius;
	public LayerMask mask;

	public string CallOverlapSphere;
	
	private void Awake()
	{
		CacheMethod(CallOverlapSphere, OverlapSphere);
	}

	private void OverlapSphere(object o)
	{
		Physics.OverlapSphere(position, radius, mask.value);
	}
}
