using UnityEngine;
using System.Collections;

public class IfIntAllConditionTrue : Base {
	[UnityEngine.Serialization.FormerlySerializedAs("conditions")]
	public Condition[] Conditions;
	public string CallCheckValue;
	public string OnTrue;
	public string OnFalse;
	
	private void Awake()
	{
		CacheMethod(CallCheckValue, CheckValue);
	}

	private void CheckValue(object o)
	{
		int val;
		if(o is int) {
			val = (int)o;
		} else if(int.TryParse(o.ToString(), out val) == false) {
			return;
		}

		string msg = IsValid(val) ? OnTrue : OnFalse;
		Call(msg, cachedGameObject);
	}

	public bool IsValid(int other) {
		bool result = true;

		for(int i = 0, max = Conditions.Length; i < max; ++i) {
			// could early return here. 
			result &= Conditions[i].IsValid(other);
		}

		return result;
	}

	[System.Serializable]
	public struct Condition
	{
		public int Value;
		public Check Range;

		public bool IsValid(int other)
		{
			switch(Range)
			{
				case Check.Equals:
					return other == Value;
				case Check.NotEquals:
					return other != Value;
				case Check.Greater:
					return other > Value;
				case Check.Lesser:
					return other < Value;
				case Check.EGreater:
					return other >= Value;
				case Check.ELesser:
					return other <= Value;
				default:
					return false;
			}
		}
	}

	public enum Check
	{
		Equals,
		NotEquals,
		Greater,
		Lesser,
		EGreater,
		ELesser
	}
}
