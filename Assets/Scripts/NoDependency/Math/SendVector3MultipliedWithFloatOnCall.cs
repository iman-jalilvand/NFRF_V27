using UnityEngine;
using System.Collections;

public class SendVector3MultipliedWithFloatOnCall : Base {
	public string CallSetValue1, CallSetValue2, CallCalculate;
	public string outgoing;

	public Vector3 value1;
	public float value2;

	private void Awake()
	{
		CacheMethod(CallSetValue1, SetValue1);
		CacheMethod(CallSetValue2, SetValue2);
		CacheMethod(CallCalculate, Calculate);
	}

	private void SetValue1(object o)
	{
		if(o != null && o is Vector3)
		{
			value1 = (Vector3) o;
		}
	}

	private void SetValue2(object o)
	{
		float f;
		if(o is float) {
			value2 = (float)o;
		} else if(o != null && float.TryParse(o.ToString(), out f))
		{
			value2 = f;
		}
	}

	private void Calculate(object o)
	{
		Vector3 result = value1 * value2;
		Call(outgoing, cachedGameObject, result);
	}
}
