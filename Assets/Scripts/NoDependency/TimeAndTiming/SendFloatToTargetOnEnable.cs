using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendFloatToTargetOnEnable : Base {
	public GameObject Target;

	public string Outgoing;
	public string CallSetTarget;
	public string CallSetValue;

	public float Value;
	

	private void Awake()
	{
		CacheMethod(CallSetTarget, SetTarget);
		CacheMethod(CallSetValue, SetValue);
	}

	private void SetTarget(object o)
	{
		if(o is Transform) {
			o = ((Transform)o).gameObject;
		}

		Target = o as GameObject;
	}

	private void SetValue(object o)
	{
		float f;
		if(o is float) {
			f = (float) o;
			Value = f;
		} else if(float.TryParse(o.ToString(), out f)) {
			Value = f;
		}
	}

	protected override void OnEnable()
	{
		Call(Outgoing, Target, Value);
	}
}
