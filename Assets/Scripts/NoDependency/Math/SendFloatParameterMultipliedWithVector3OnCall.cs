using UnityEngine;
using System.Collections;

public class SendFloatParameterMultipliedWithVector3OnCall : Base {

    public string Incoming;
	public string Outgoing;
	public string CallSetValue;
    public Vector3 Value;
	
	private void Awake () {
        CacheMethod(CallSetValue, SetValue);
        CacheMethod(Incoming, Multiply);
    }
    
	private void SetValue(object o)
    {
		if(o is Vector3) {
			Value = (Vector3)o;
		}
    }

	private void Multiply (object o) {
        if(o is float)
        {
            Call(Outgoing, cachedGameObject, ((float)o) * Value);
        }
	}
}
