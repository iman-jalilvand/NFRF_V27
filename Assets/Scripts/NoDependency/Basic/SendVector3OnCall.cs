using UnityEngine;
using System.Collections;

public class SendVector3OnCall : Base {
	[UnityEngine.Serialization.FormerlySerializedAs("value")]
	public Vector3 Value;
	[UnityEngine.Serialization.FormerlySerializedAs("callSend")]
	public string CallSend;
	[UnityEngine.Serialization.FormerlySerializedAs("methodName")]
	public string Outgoing;
	public string CallSetValue;

	public Behaviour sendTo;

	private void Awake()
	{
		CacheMethod(CallSend, Send);
		CacheMethod(CallSetValue, SetValue);
	}

	private void SetValue(object o)
	{
		if(o != null && o is Vector3) {
			Value = (Vector3) o;
		}
	}

	private void Send(object o)
	{
		switch(sendTo) {
			case Behaviour.All:
				Call(Outgoing, typeof(Base), Value);
				break;
			case Behaviour.Self:
				Call(Outgoing, cachedGameObject, Value);
				break;
		}
	}

	public enum Behaviour
	{
		Self, 
		All
	}
}
