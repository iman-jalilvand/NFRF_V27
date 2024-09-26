using UnityEngine;
using System.Collections;

public class SendVector3ParameterMultipliedWithFloatOnCall : Base {

    public string Incoming;
	public string Outgoing;
	public string CallSetValue;
    public float Value;
	
	private void Awake () {
        CacheMethod(CallSetValue, SetValue);
        CacheMethod(Incoming, Multiply);
    }
    
	private void SetValue(object o)
    {
		float f;
		if(o is float) {
			Value = (float)o;
		} else if (float.TryParse(o.ToString(), out f))
        {
            Value = f;
        }
    }

	private void Multiply (object o) {
        if(o is Vector3)
        {
            Call(Outgoing, cachedGameObject, ((Vector3)o) * Value);
        }
	}
}
