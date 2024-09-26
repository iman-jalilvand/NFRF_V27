using UnityEngine;
using System.Collections;

public class SendPositionFromTargetOnCall : Base {
	public string CallSendPosition;
	public string CallSetTarget;
	public string Outgoing;

	public Transform Target;

	private void Awake()
	{
		CacheMethod(CallSendPosition, SendPosition);
		CacheMethod(CallSetTarget, SetTarget);
	}

	private void SendPosition(object o)
	{
		Call(Outgoing, cachedGameObject, Target.position);
	}

	private void SetTarget(object o)
	{
		Target = ExtractTransform(o);
	}

	private Transform ExtractTransform(object o)
	{
		Transform go;
		if(o is GameObject) {
			o = ((GameObject)o).transform;
		}
		go = o as Transform;
		return go;
	}
}
