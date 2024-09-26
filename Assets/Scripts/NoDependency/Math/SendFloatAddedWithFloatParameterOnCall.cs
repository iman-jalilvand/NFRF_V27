using UnityEngine;
using System.Collections;

public class SendFloatAddedWithFloatParameterOnCall : Base {
	public float Value;
    public string CallSetValue;
    public string CallAdd;
    public string OutgoingAdd;


    private void Awake()
    {
        CacheMethod(CallSetValue, SetMultiplier);
        CacheMethod(CallAdd, Multiply);
    }

    private void SetMultiplier(object o)
    {
        float f;
        if (float.TryParse(o.ToString(), out f))
        {
            Value = f;
        }
    }

    private void Multiply(object o)
    {
        float value;
        if (o is float)
        {
            value = (float)o;
            float result = value + Value;
            Call(OutgoingAdd, cachedGameObject, result);
        }
        else if (float.TryParse(o.ToString(), out value))
        {
            float result = value + Value;
            Call(OutgoingAdd, cachedGameObject, result);
        }
    }

}
