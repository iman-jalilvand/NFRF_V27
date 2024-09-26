using UnityEngine;
using System.Collections;

public class FloatStore : Base {

    public string Incoming;
    public string Outgoing;
    public string CallSetValue;
    public float Value;
    private void Awake()
    {
        CacheMethod(Incoming, SendFloat);
        CacheMethod(CallSetValue, SetValue);
    }
    private void SetValue(object o)
    {
        if(o is float)
        {
            Value = (float)o;
        }
    }
	private void SendFloat(object o)
	{
        Call(Outgoing, cachedGameObject, Value);
	}
}
