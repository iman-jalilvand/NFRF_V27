using UnityEngine;
using System.Collections;
using System;

public class SendStringByArraySizeOnCall : Base {
	[UnityEngine.Serialization.FormerlySerializedAs("callSendStringByArraySize")]
	public string Incoming;
	[UnityEngine.Serialization.FormerlySerializedAs("cases")]
	public Check[] Cases;

	private void Awake()
	{
		CacheMethod(Incoming, SendStringbyArraySize);
	}

	private void SendStringbyArraySize(object o)
	{
		if(o.GetType().IsArray) {
			Array array = (Array) o;
			for(int i = 0, max = Cases.Length; i < max; ++i) {
				Check c = Cases[i];
				bool isValid = c.Validate(array);
				if(isValid) {
					Send(c);
				}
			}
		}
	}

	private void Send(Check c) {
		switch(c.SendTo) {
			case Behaviour.All:
				Call(c.Outgoing, typeof(Base), c.Parameter);
				break;
			case Behaviour.Self:
				Call(c.Outgoing, cachedGameObject, c.Parameter);
				break;
		}
	}

	[System.Serializable]
	public struct Check
	{
		public Condition Condition;
		public Behaviour SendTo;
		public int Count;
		public string Outgoing;
		public string Parameter;

		public bool Validate(Array array)
		{
			int arraySize = array.Length;
			switch(Condition) {
				case Condition.GreaterThan:
					return arraySize > Count;
				case Condition.LessThan:
					return arraySize < Count;
				case Condition.Not:
					return Count != arraySize;
				case Condition.EqualTo:
				default:
					return Count == arraySize;
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
