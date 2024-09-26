using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendInstantiatedGameObjectParameterAtSelfPositionAndRotationOnCall : Base {
	public string CallSendInstantiatedParameter;
	public string Outgoing;

	private void Awake()
	{
		CacheMethod(CallSendInstantiatedParameter, SendInstantiatedParameter);
	}

	private void SendInstantiatedParameter(object o)
	{
		GameObject target = o as GameObject;
		if(target == null) {
			return;
		}

		GameObject spawned = Instantiate(target, cachedTransform.position, cachedTransform.rotation);
		Call(Outgoing, cachedGameObject, spawned);
	}
}
