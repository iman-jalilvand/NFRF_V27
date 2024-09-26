using UnityEngine;
using System.Collections;

public class SendRayFromSelfToTargetOnUpdate : Base
{
	public string CallSetTarget;
	public string Outgoing;

	public Transform Target;

	private void Awake()
	{
		CacheMethod(CallSetTarget, SetTarget);
	}

	private void Update()
	{
		Vector3 selfPosition = cachedTransform.position;
		Vector3 targetPosition = Target.position;
		Vector3 direction = (targetPosition - selfPosition);//.normalized; // no real reason to normalize here. 
		Ray ray = new Ray(selfPosition, direction);
		
		Call(Outgoing, cachedGameObject, ray);
	}

	private void SetTarget(object o)
	{
		if(o is GameObject) {
			o = ((GameObject) o).transform;
		}

		if(o is Transform) {
			Target = (Transform) o;
		}
	}
}
