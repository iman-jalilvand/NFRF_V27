using UnityEngine;
using System.Collections;

public class FloatStoreWithAddAndSubtractParameter : Base {

    public string Incoming;
    public string Outgoing;
    public string CallAddValue;
    public string CallSubtractValue;
    public string CallSetValue;
    public float Value;
    private void Awake()
    {
        CacheMethod(Incoming, SendFloat);
        CacheMethod(CallSetValue, SetValue);
        CacheMethod(CallAddValue, AddValue);
        CacheMethod(CallSubtractValue, SubtractValue);
    }
    private void AddValue(object o)
    {
        if (o is float)
        {
            Value += (float)o;
        }
    }
    private void SubtractValue(object o)
    {
        if (o is float)
        {
            Value -= (float)o;
        }
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
