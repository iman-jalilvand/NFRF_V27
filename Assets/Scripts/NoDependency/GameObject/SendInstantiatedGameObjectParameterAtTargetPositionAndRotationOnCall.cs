using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendInstantiatedGameObjectParameterAtTargetPositionAndRotationOnCall : Base {
	public string CallSendInstantiatedParameter;
	public string CallSetTarget;
	
	public string Outgoing;

	public Transform Target;

	private void Awake()
	{
		CacheMethod(CallSendInstantiatedParameter, SendInstantiatedParameter);
		CacheMethod(CallSetTarget, SetTarget);
	}

	private void SetTarget(object o)
	{
		if(o is GameObject) {
			Target = ((GameObject) o).transform;
		}

		Target = o as Transform;
	}

	private void SendInstantiatedParameter(object o)
	{
		GameObject target = o as GameObject;
		if(target == null) {
			return;
		}

		GameObject spawned = Instantiate(target, Target.position, Target.rotation);
		Call(Outgoing, cachedGameObject, spawned);
	}
}
