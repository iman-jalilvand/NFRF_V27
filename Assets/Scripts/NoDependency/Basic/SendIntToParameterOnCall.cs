using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;

public class SendIntToParameterOnCall : Base {
	[UnityEngine.Serialization.FormerlySerializedAs("callSendIntToParameter")]
	public string CallSendIntToParameter;
	public string CallSetInt;

	[FormerlySerializedAs("methodName")]
	[UnityEngine.Serialization.FormerlySerializedAs("outgoing")]
	public string Outgoing;
	[UnityEngine.Serialization.FormerlySerializedAs("value")]
	public int Value;
	
	private void Awake()
	{
		CacheMethod(CallSendIntToParameter, SendIntToParameter);
		CacheMethod(CallSetInt, SetInt);
	}

	private void SetInt(object o)
	{
		if(!(o is int)) {
			return;
		}

		Value = (int) o;
	}

	private void SendIntToParameter(object o)
	{
		if(o is GameObject) {
			Call(Outgoing, (GameObject) o, Value);
		}
	}
}
