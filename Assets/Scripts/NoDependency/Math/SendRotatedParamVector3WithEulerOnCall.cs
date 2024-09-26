using UnityEngine;
using System.Collections;

public class SendRotatedParamVector3WithEulerOnCall : Base {
	public Vector3 Euler;

	public string CallSend;
	public string CallSetEuler;
	public string Outgoing;

	private void Awake()
	{
		CacheMethod(CallSend, Send);
		CacheMethod(CallSetEuler, SetEuler);
	}

	private void Send(object o)
	{
		Vector3 value;
		if(o is Vector3) {
			value = (Vector3) o;
			Vector3 rotated = Quaternion.Euler(Euler) * value;
			Call(Outgoing, cachedGameObject, rotated);
		}
	}

	private void SetEuler(object o)
	{
		Euler = (Vector3) o;
	}
}
