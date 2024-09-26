using UnityEngine;
using System.Collections;

public class SendIntOnCall : Base {
	[UnityEngine.Serialization.FormerlySerializedAs("value")]
	public int Value;
	[UnityEngine.Serialization.FormerlySerializedAs("callSendInt")]
	public string CallSendInt;
	[UnityEngine.Serialization.FormerlySerializedAs("methodName")]
	public string Outgoing;

	public Behaviour sendTo;

	private void Awake()
	{
		CacheMethod(CallSendInt, SendInt);
	}

	private void SendInt(object o)
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
