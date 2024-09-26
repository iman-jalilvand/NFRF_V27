using UnityEngine;
using System.Collections;

public class IfString : Base {
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
		if(!(o is string)) {
			return;
		}
        string val = (string) o;
		string msg = IsValid(val) ? OnTrue : OnFalse;
		Call(msg, cachedGameObject);
	}

	public bool IsValid(string other) {
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
		public string Value;
		public Check Range;

		public bool IsValid(string other)
		{
			switch(Range)
			{
				case Check.Equals:
					return other == Value;
				case Check.NotEquals:
					return other != Value;
				default:
					return false;
			}
		}
	}

	public enum Check
	{
		Equals,
		NotEquals,
	}
}
