using UnityEngine;
using System.Collections;

public class SendIntMultipliedWithIntOnCall : Base
{
	public string CallSetValue1, CallSetValue2, CallCalculate;
	public string Outgoing;

	public int Value1;
	public int Value2;
	public int MinValue = 1;

	private void Awake()
	{
		CacheMethod(CallSetValue1, SetValue1);
		CacheMethod(CallSetValue2, SetValue2);
		CacheMethod(CallCalculate, Calculate);
	}

	private void SetValue1(object o)
	{
		int i;
		if (o is int) {
			i = (int)o;
			Value1 = i;
			Value1 = Mathf.Max(MinValue, Value1);
		} else if (o != null && int.TryParse(o.ToString(), out i)) {
			Value1 = i;
			Value1 = Mathf.Max(MinValue, Value1);
		}
	}

	private void SetValue2(object o)
	{
		int i;
		if (o is int) {
			i = (int)o;
			Value2 = i;
			Value2 = Mathf.Max(MinValue, Value2);
		} else if (o != null && int.TryParse(o.ToString(), out i)) {
			Value2 = i;
			Value2 = Mathf.Max(MinValue, Value2);
		}
	}

	private void Calculate(object o)
	{
		int result = Value1 * Value2;
		Call(Outgoing, cachedGameObject, result);
	}
}
