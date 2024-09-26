using UnityEngine;
using System.Collections;

public class SendFloatValueSubtractWithFloatParameterOnCall : Base {
	public float Value;
	public string Incoming;
	public string Outgoing;

	private void Awake()
	{
		CacheMethod(Incoming, Calc);
	}

	private void Calc(object o)
	{
		float f;
		if(o is float) {
			f = (float) o;
			float result = Value - f;
			Call(Outgoing, cachedGameObject, result);
		} else if(float.TryParse(o.ToString(), out f)) {
			float result = Value - f;
			Call(Outgoing, cachedGameObject, result);
		}
	}
	
}
