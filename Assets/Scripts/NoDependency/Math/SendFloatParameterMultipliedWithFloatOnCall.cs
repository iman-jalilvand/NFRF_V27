using UnityEngine;
using System.Collections;

public class SendFloatParameterMultipliedWithFloatOnCall : Base {
	public float Multiplier;
	public string CallSetMultiplier;
	public string CallMultiply;
	public string OutgoingMultiply;


	private void Awake()
	{
		CacheMethod(CallSetMultiplier, SetMultiplier);
		CacheMethod(CallMultiply, Multiply);
	}

	private void SetMultiplier(object o)
	{
		float f;
		if(float.TryParse(o.ToString(), out f)) {
			Multiplier = f;
		}
	}

	private void Multiply(object o)
	{
		float value;
		if(o is float) {
			value = (float) o;
			float result = value * Multiplier;
			Call(OutgoingMultiply, cachedGameObject, result);
		} else if(float.TryParse(o.ToString(), out value)) {
			float result = value * Multiplier;
			Call(OutgoingMultiply, cachedGameObject, result);
		}
	}

}
