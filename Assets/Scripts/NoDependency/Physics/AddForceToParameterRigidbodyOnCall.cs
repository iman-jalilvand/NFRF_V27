using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceToParameterRigidbodyOnCall : Base {
	public Vector3 Force;
	public string CallSetForce;
	public string CallAddForce;
	private void Awake()
	{
		CacheMethod(CallSetForce, SetForce);
		CacheMethod(CallAddForce, AddForce);
	}

	private void SetForce(object o)
	{
		if(o is Vector3) {
			Force = (Vector3)o;
		}
	}

	private void AddForce(object o)
	{
		if(o is GameObject) {
			o = ((GameObject)o).GetComponent<Rigidbody>();
		}

		if(o is Transform) {
			o = ((Transform)o).GetComponent<Rigidbody>();
		}

		Rigidbody rb = o as Rigidbody;
		rb.AddForce(Force);
	}
}
