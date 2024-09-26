using UnityEngine;
using System.Collections;

public class OrParameterGate : Base
{
    public string Incoming;
	public string Outgoing;
    public string CallSetValue;
    public bool Value;

    private void Awake()
    {
        CacheMethod(Incoming, IncomingMethod);
        CacheMethod(CallSetValue, IncomingMethod);
    }

    private void SetValue(object o)
    {
        if(o is bool)
        {
            Value = (bool)o;
        }
    }
    private void IncomingMethod(object o)
    {
        bool b;
        if (o is bool)
        {
            b = (bool)o;
            if (Value || b)
            {
                Call(Outgoing, cachedGameObject, b);
            }
        }
    }
    
}
