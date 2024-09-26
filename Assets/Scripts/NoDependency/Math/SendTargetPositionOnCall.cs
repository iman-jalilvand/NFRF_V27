using UnityEngine;
using System.Collections;

public class SendTargetPositionOnCall : Base {
	public Transform Target;
	public string CallSend;
	public string CallSetTarget;
	public string Outgoing;

	private void Awake()
	{
		CacheMethod(CallSend, Send);
		CacheMethod(CallSetTarget, SetTarget);
	}

	private void Send(object o)
	{
		if(Target != null) {
			Call(Outgoing, cachedGameObject, Target.position);
		}
	}

	private void SetTarget(object o)
	{
		if(o is GameObject) {
			o = ((GameObject)o).transform;
		}

		Target = o as Transform;
	}
}
