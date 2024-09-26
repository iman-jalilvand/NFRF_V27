using UnityEngine;
using System.Collections;

public class SendFloatParameterSubtractedWithFloatOnCall : Base
{
	public string Incoming;
	public string Outgoing;
	public string CallAddToSubtractingValue;
	public float SubtractingValue;

	protected virtual void Awake()
	{
		CacheMethod(Incoming, Subtract);
		CacheMethod(CallAddToSubtractingValue, (o) =>
		{
			float f = float.Parse(o.ToString());
			SubtractingValue += f;
		});
	}

	protected virtual void Subtract(object o)
	{
		float value;
		if (o is float) {
			value = (float)o;
			value -= SubtractingValue;
		} else if (float.TryParse(o.ToString(), out value)) {
			value -= SubtractingValue;
		}
		Call(Outgoing, cachedGameObject, value);
	}
}
