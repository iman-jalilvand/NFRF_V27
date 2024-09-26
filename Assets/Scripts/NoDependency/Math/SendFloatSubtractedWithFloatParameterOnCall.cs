using UnityEngine;
using System.Collections;

public class SendFloatSubtractedWithFloatParameterOnCall : Base {
	public string Incoming;
	public string Outgoing;
    public string CallSetValue;
	public float Value;

	private void Awake()
    {
        CacheMethod(Incoming, Subtract);
        CacheMethod(CallSetValue, SetValue);
    }
    private void SetValue(object o)
    {
        float f;
        if (o is float)
        {
            f = (float)o;
            Value = f;
        }
        else if (o is int)
        {
            f = (float)(int)o;
            Value = f;
        }
        else if (float.TryParse(o.ToString(),out f))
        {
            Value = f;
        }
    }
	private void Subtract(object o)
	{
		float value;
		if(o is float) {
			value = Value;
			value -= (float)o;
		} else if(float.TryParse(o.ToString(), out value))
		{
			value = Value - value;
		}
		Call(Outgoing, cachedGameObject, value);
	}
}
