using UnityEngine;
using System.Collections;

public class SendIncrementedCountOnCall : Base {
	[UnityEngine.Serialization.FormerlySerializedAs("methodName")]
	public string Incoming;
	[UnityEngine.Serialization.FormerlySerializedAs("callCount")]
	public string CallCount;
	[UnityEngine.Serialization.FormerlySerializedAs("resetOnEnable")]
	public bool ResetOnEnable = true;
	[UnityEngine.Serialization.FormerlySerializedAs("sendTo")]
	public Behaviour SendTo;
	private int count;

	private void Awake()
	{
		CacheMethod(CallCount, Count);
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		if(ResetOnEnable) {
			count = 0;
		}
	}


	private void Count(object o)
	{
		switch(SendTo)
		{
			case Behaviour.All:
				Call(Incoming, typeof(Base), ++count);
				break;
			case Behaviour.Self:
				Call(Incoming, cachedGameObject, ++count);
				break;
		}
	}

	public enum Behaviour 
	{
		Self, 
		All
	}
}
