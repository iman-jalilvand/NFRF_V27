using UnityEngine;
using System.Collections;

public class IfFloatAllConditionTrue : Base {
	[UnityEngine.Serialization.FormerlySerializedAs("conditions")]
	public Condition[] Conditions;
    public string CallSetConditionIndex;
    public string CallSetConditionValue;
	public string CallCheckValue;
	public string OnTrue;
	public string OnFalse;
    public int SetValueIndex;
	private void Awake()
    {
        CacheMethod(CallCheckValue, CheckValue);
        CacheMethod(CallSetConditionIndex, SetIndex);
        CacheMethod(CallSetConditionValue, SetConditionValue);
    }
    void SetIndex(object o)
    {
        if(o is float)
        {
            SetValueIndex = (int)o;
        }
    }
    void SetConditionValue(object o)
    {
        if (o is float || o is int)
        {
            Conditions[SetValueIndex].Value = (float)o;
        }
    }
	private void CheckValue(object o)
    {
        float f;
        if (o is float)
        {
            f = (float)o;
            string msg = IsValid(f) ? OnTrue : OnFalse;
            Call(msg, cachedGameObject);
        }
        else if (o is int)
        {
            f = (float)(int)o;
            string msg = IsValid(f) ? OnTrue : OnFalse;
            Call(msg, cachedGameObject);
        }
        else if (float.TryParse(o.ToString(), out f))
        {
            string msg = IsValid(f) ? OnTrue : OnFalse;
            Call(msg, cachedGameObject);
        }
    }

	public bool IsValid(float other) {
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
		public float Value;
		public Check Range;

		public bool IsValid(float other)
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
