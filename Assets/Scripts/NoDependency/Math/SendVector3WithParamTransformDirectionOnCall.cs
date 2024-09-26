using UnityEngine;
using System.Collections;

public class SendVector3WithParamTransformDirectionOnCall : Base {
	public string CallSend;
	public string CallSetLocalDirection;
	public string Outgoing;

	public Vector3 LocalDirection;

	private void Awake()
	{
		CacheMethod(CallSend, TransformDirection);
		CacheMethod(CallSetLocalDirection, SetLocalDirection);
	}

	private void TransformDirection(object o)
	{
		if(o is GameObject) {
			o = ((GameObject)o).transform;
		}

		if(o is Transform) {
			Transform target = (Transform) o;
			Vector3 globalDirection = target.TransformDirection(LocalDirection);
			Call(Outgoing, cachedGameObject, globalDirection);
		}
	}

	private void SetLocalDirection(object o)
	{
		if(o is Vector3) {
			LocalDirection = (Vector3) o;
		}
	}
}
