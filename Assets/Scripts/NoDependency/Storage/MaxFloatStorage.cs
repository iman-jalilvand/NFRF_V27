using UnityEngine;
using System.Collections;

public class MaxFloatStorage : Base {

    public string Outgoing;
    public string SendOnMaxChanged;
    public string CallSendStoredFloat;
    public string CallSetFloatMax;
    public string CallSetFloat;
    public float StoredFloat;
	// Use this for initialization
	void Awake ()
    {
        CacheMethod(CallSendStoredFloat, SendStoredFloat);
        CacheMethod(CallSetFloatMax, SetMax);
        CacheMethod(CallSetFloat, SetFloat);
    }
    void SendStoredFloat(object o)
    {
        Call(Outgoing, cachedGameObject, StoredFloat);
    }
    void SetMax(object o)
    {
        if (o is float)
        {
            float f = (float)o;
            if (f > StoredFloat)
            {
                StoredFloat = f;
                Call(SendOnMaxChanged, cachedGameObject);
            }
        }
    }
    void SetFloat(object o)
    {
        if (o is float)
        {
            StoredFloat = (float)o;
        }
    }
}
