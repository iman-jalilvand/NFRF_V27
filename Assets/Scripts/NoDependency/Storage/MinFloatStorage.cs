using UnityEngine;
using System.Collections;

public class MinFloatStorage : Base
{

    public string Outgoing;
    public string SendOnMinChanged;
    public string CallSendStoredFloat;
    public string CallSetFloatMin;
    public string CallSetFloat;
    public float StoredFloat;
    // Use this for initialization
    void Awake()
    {
        CacheMethod(CallSendStoredFloat, SendStoredFloat);
        CacheMethod(CallSetFloatMin, SetMin);
        CacheMethod(CallSetFloat, SetFloat);
    }
    void SendStoredFloat(object o)
    {
        Call(Outgoing, cachedGameObject, StoredFloat);
    }
    void SetMin(object o)
    {
        if (o is float)
        {
            float f = (float)o;

            if (f < StoredFloat)
            {
                StoredFloat = f;
                Call(SendOnMinChanged, cachedGameObject, StoredFloat);
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
