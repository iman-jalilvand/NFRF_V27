using UnityEngine;
using System.Collections;

public class VigilantIntStoreWithAddAndSubtractParameter : Base {

    public string Incoming;
    public string Outgoing;
    public string CallAddValue;
    public string CallSubtractValue;
    public string CallSetValue;
    public int Value;

    private void Awake()
    {
        CacheMethod(Incoming, SendFloat);
        CacheMethod(CallSetValue, SetValue);
        CacheMethod(CallAddValue, AddValue);
        CacheMethod(CallSubtractValue, SubtractValue);
    }
    protected override void OnEnable()
    {
        //
    }
    protected override void OnDisable()
    {
        //
    }
    private void AddValue(object o)
    {
        if (o is int)
        {
            Value += (int)o;
        }
    }
    private void SubtractValue(object o)
    {
        if (o is int)
        {
            Value -= (int)o;
        }
    }
    private void SetValue(object o)
    {
        if(o is int)
        {
            Value = (int)o;
        }
    }
	private void SendFloat(object o)
	{
        Call(Outgoing, cachedGameObject, Value);
	}
}
