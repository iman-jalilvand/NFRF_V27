using UnityEngine;
using System.Collections;

public class SendFloatByIntOnCall : Base {
	[UnityEngine.Serialization.FormerlySerializedAs("callSendFloatByInt")]
	public string CallSendFloatByInt;
	[UnityEngine.Serialization.FormerlySerializedAs("cases")]
	public Check[] Cases;

	private void Awake()
	{
		CacheMethod(CallSendFloatByInt, SendFloatByInt);
	}

	private void SendFloatByInt(object o)
	{
		if(o is int) {
			int given = (int) o;
			for(int i = 0, max = Cases.Length; i < max; ++i) {
				Check c = Cases[i];
				bool isValid = c.Validate(given);
				if(isValid) {
					Send(c);
				}
			}
		}
	}

	private void Send(Check c) {
		switch(c.sendTo) {
			case Behaviour.All:
				Call(c.message, typeof(Base), c.parameter);
				break;
			case Behaviour.Self:
				Call(c.message, cachedGameObject, c.parameter);
				break;
		}
	}

	[System.Serializable]
	public struct Check
	{
		public Condition condition;
		public Behaviour sendTo;
		public int value;
		public string message;
		public float parameter;

		public bool Validate(int given)
		{
			switch(condition) {
				case Condition.GreaterThan:
					return given > value;
				case Condition.LessThan:
					return given < value;
				case Condition.Not:
					return given != value;
				case Condition.EqualTo:
				default:
					return given == value;
			}
		}
	}

	public enum Condition
	{
		EqualTo,
		Not,
		GreaterThan,
		LessThan,
	}

	public enum Behaviour
	{
		Self, 
		All
	}
}
