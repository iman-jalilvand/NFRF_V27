using UnityEngine;
using System.Collections;

public class SendFloatMultipliedWithFloatOnCall : Base {
	public string CallSetValue1, CallSetValue2, CallCalculate;
	[UnityEngine.Serialization.FormerlySerializedAs("outgoing")]
	public string Outgoing;

	[UnityEngine.Serialization.FormerlySerializedAs("value1")]
	public float Value1;
	[UnityEngine.Serialization.FormerlySerializedAs("value2")]
	public float Value2;
	public float MinValue = 1;

	private void Awake()
	{
		CacheMethod(CallSetValue1, SetValue1);
		CacheMethod(CallSetValue2, SetValue2);
		CacheMethod(CallCalculate, Calculate);
	}

	private void SetValue1(object o)
	{
		float f;
		if(o is float) {
			f = (float) o;
			Value1 = f;
			Value1 = Mathf.Max(MinValue, Value1);
		} else if(o != null && float.TryParse(o.ToString(), out f))
		{
			Value1 = f;
			Value1 = Mathf.Max(MinValue, Value1);
		}
	}

	private void SetValue2(object o)
	{
		float f;
		if(o != null && float.TryParse(o.ToString(), out f))
		{
			Value2 = f;
			Value2 = Mathf.Max(MinValue, Value2);
		}
	}

	private void Calculate(object o)
	{
		float result = Value1 * Value2;
		Call(Outgoing, cachedGameObject, result);
	}
}
