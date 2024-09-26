using UnityEngine;
using System.Collections;

public class IfInt : Base {
	[UnityEngine.Serialization.FormerlySerializedAs("conditions")]
	public Condition IfCondition;
	public string CallCheckValue;
	public string OnTrue;
	public string OnFalse;
    public string CallSetConditionValue;

    private void Awake()
    {
        CacheMethod(CallCheckValue, CheckValue);
        CacheMethod(CallSetConditionValue, SetConditionValue);
    }
    private void SetConditionValue(object o)
    {
        int i;
        if (o is int)
        {
            i = (int)o;
            IfCondition.Value = i;
        }
        else if (o is float)
        {
            i = (int)o;
            IfCondition.Value = i;
        }
        if (int.TryParse(o.ToString(),out i))
        {
            IfCondition.Value = i;
        }
    }
	private void CheckValue(object o)
	{
		int val;
		if(int.TryParse(o.ToString(), out val) == false) {
			return;
		}

		string msg = IsValid(val) ? OnTrue : OnFalse;
		Call(msg, cachedGameObject);
	}

	public bool IsValid(int other) {
        bool result = true;
        result &= IfCondition.IsValid(other);

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
