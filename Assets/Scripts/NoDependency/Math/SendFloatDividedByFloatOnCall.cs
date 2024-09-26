using UnityEngine;
using System.Collections;

public class SendFloatDividedByFloatOnCall : Base {
	public float Numerator;
	public float Denominator;
	public string CallCalculate;
	public string CallSetNumerator;
	public string CallSetDenominator;
	public string Outgoing;

	public bool SafeguardZero = true;

	private void Awake()
	{
		CacheMethod(CallCalculate, Calculate);
		CacheMethod(CallSetNumerator, SetNumerator);
		CacheMethod(CallSetDenominator, SetDenominator);
	}

	private void Calculate(object o)
	{
		if(SafeguardZero && Denominator == 0) {
			Denominator = float.Epsilon;
		}

		Call(Outgoing, cachedGameObject, Numerator / Denominator);
	}

	private void SetNumerator(object o)
	{
		float f;
		if(o is float) {
			Numerator = (float)o;
		} else if(o != null && float.TryParse(o.ToString(), out f)) {
			Numerator = f;
		}
	}

	private void SetDenominator(object o)
	{
		float f;
		if(o is float) {
			Denominator = (float)o;
		} else if(o != null && float.TryParse(o.ToString(), out f)) {
			Denominator = f;
		}
	}
}
