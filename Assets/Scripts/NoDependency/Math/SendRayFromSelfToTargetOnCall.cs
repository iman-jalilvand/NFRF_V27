using UnityEngine;
using System.Collections;

public class SendRayFromSelfToTargetOnCall : Base
{
	public string CallSetTarget;
	public string CallSend;
	public string Outgoing;

	public Transform Target;

	private void Awake()
	{
		CacheMethod(CallSetTarget, SetTarget);
		CacheMethod(CallSend, Send);
	}

	private void Send(object o)
	{
		if(Target == null) {
			return;
		}

		Vector3 selfPosition = cachedTransform.position;
		Vector3 targetPosition = Target.position;
		Vector3 direction = (targetPosition - selfPosition);//.normalized; // no real reason to normalize here. 
		Ray ray = new Ray(selfPosition, direction);
		
		Call(Outgoing, cachedGameObject, ray);
	}

	private void SetTarget(object o)
	{
		if(o is GameObject && ((GameObject)o != null)) {
			o = ((GameObject) o).transform;
		}

		if(o is Transform) {
			Target = (Transform) o;
		}
	}
}
