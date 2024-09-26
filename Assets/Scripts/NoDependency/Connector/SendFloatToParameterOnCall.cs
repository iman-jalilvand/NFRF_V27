using UnityEngine;
using System.Collections;

public class SendFloatToParameterOnCall : Base {
	[UnityEngine.Serialization.FormerlySerializedAs("callSetFloat")]
	public string CallSetFloat;
	[UnityEngine.Serialization.FormerlySerializedAs("incoming")]
	public string Incoming;
	[UnityEngine.Serialization.FormerlySerializedAs("outgoing")]
	public string Outgoing;

	public float value;

	private void Awake()
	{
		CacheMethod(Incoming, Send);
		CacheMethod(CallSetFloat, SetFloat);
	}

	private void SetFloat(object o)
	{
		if(o is float) {
			value = (float) o;
		}
	}

	private void Send(object o) {
		GameObject go = o as GameObject;
		if(go == null) {
			return;
		}

		Call(Outgoing, go, value);
	}
}
