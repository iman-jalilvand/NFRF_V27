using UnityEngine;
using System.Collections;

public class SendCountOnCall : Base {
	public string methodName;
	public string callCount;
	public bool resetOnEnable = true;
	public Behaviour sendTo;
	private int count;

	private void Awake()
	{
		CacheMethod(callCount, Count);
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		if(resetOnEnable) {
			count = 0;
		}
	}


	private void Count(object o)
	{
		switch(sendTo)
		{
			case Behaviour.All:
				Call(methodName, typeof(Base), ++count);
				break;
			case Behaviour.Self:
				Call(methodName, cachedGameObject, ++count);
				break;
		}
	}

	public enum Behaviour 
	{
		Self, 
		All
	}
}
