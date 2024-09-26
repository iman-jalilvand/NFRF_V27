using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTargetWithVector3ParameterOnCall : Base
{
	public string Incoming;
	public string CallSetTarget;

	public Transform Target;
	private void Awake()
	{
		CacheMethod(Incoming, Move);
		CacheMethod(CallSetTarget, SetTarget);
	}
	private void SetTarget(object o)
	{
		if (o is GameObject) {
			Target = ((GameObject)o).transform;
		} else if (o is GameObject) {
			Target = (Transform)o;
		} else if (o is Component) {
			Target = ((Component)o).transform;
		}
	}
	private void Move(object o)
	{
		Vector3 parameter = (Vector3)o;
		parameter = Target.InverseTransformDirection(parameter);
		Target.position += parameter;
	}
}