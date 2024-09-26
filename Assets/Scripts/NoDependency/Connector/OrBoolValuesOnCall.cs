using UnityEngine;
using System.Collections;

public class OrBoolValuesOnCall : Base
{
    public string Incoming;
    public string OutgoingOnTrue;
    public string OutgoingOnFalse;
    public string CallSetValue1;
    public string CallSetValue2;
    public bool Value1;
    public bool Value2;

    private void Awake()
    {
        CacheMethod(Incoming, IncomingMethod);
        CacheMethod(CallSetValue1, SetValue1);
        CacheMethod(CallSetValue2, SetValue2);
    }

    private void SetValue1(object o)
    {
        if (o is bool)
        {
            Value1 = (bool)o;
        }
    }
    private void SetValue2(object o)
    {
        if (o is bool)
        {
            Value2 = (bool)o;
        }
    }
    private void IncomingMethod(object o)
    {
        if (Value1 || Value2)
        {
            Call(OutgoingOnTrue, cachedGameObject);
        }
        else
        {
            Call(OutgoingOnFalse, cachedGameObject);
        }
    }
    
}
