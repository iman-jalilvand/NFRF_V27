using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendInstantiatedGameObjectParameterAtPositionAndRotationOnCall : Base {
	public string CallSendInstantiatedParameter;
	public string CallSetPosition;
	public string CallSetRotation;
	public string CallSetPositionAndRotationWithTransform;
	public string Outgoing;

	public Vector3 Position;
	public Quaternion Rotation;

	private void Awake()
	{
		CacheMethod(CallSendInstantiatedParameter, SendInstantiatedParameter);
		CacheMethod(CallSetPosition, SetPosition);
		CacheMethod(CallSetRotation, SetRotation);
		CacheMethod(CallSetPositionAndRotationWithTransform, SetPositionAndRotationWithTransform);
	}

	private void SendInstantiatedParameter(object o)
	{
		GameObject target = o as GameObject;
		if(target == null) {
			return;
		}

		GameObject spawned = Instantiate(target, Position, Rotation);
		Call(Outgoing, cachedGameObject, spawned);
	}

	private void SetPosition(object o)
	{
		Vector3 pos = Vector3.zero;

		if(o is Transform) {
			o = ((Transform)o).position;
		}

		if(o is Vector3)
		{
			pos = (Vector3) o;
		}

		Position = pos;
	}

	private void SetRotation(object o)
	{
		Quaternion rot = Quaternion.identity;

		if(o is Transform) {
			o = ((Transform)o).rotation;
		}

		if(o is Quaternion) {
			o = (Quaternion) o;
		}

		Rotation = rot;
	}

	private void SetPositionAndRotationWithTransform(object o)
	{
		SetPosition(o);
		SetRotation(o);
	}
}
