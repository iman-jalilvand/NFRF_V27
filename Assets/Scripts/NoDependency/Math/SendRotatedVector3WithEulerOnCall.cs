using UnityEngine;
using System.Collections;

public class SendRotatedVector3WithEulerOnCall : Base {
	public Vector3 Value;
	public Vector3 Euler;

	public string CallSend;
	public string CallSetValue;
	public string CallSetEuler;
	public string Outgoing;

	private void Awake()
	{
		CacheMethod(CallSend, Send);
		CacheMethod(CallSetValue, SetValue);
		CacheMethod(CallSetEuler, SetEuler);
	}

	private void Send(object o)
	{
		Vector3 rotated = Quaternion.Euler(Euler) * Value;
		Call(Outgoing, cachedGameObject, rotated);
	}

	private void SetValue(object o)
	{
		Value = (Vector3) o;
	}

	private void SetEuler(object o)
	{
		Euler = (Vector3) o;
	}
}
