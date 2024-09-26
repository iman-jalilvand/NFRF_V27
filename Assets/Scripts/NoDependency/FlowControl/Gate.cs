using UnityEngine;
using System.Collections;

public class Gate : Base
{
    [UnityEngine.Serialization.FormerlySerializedAs("open")]
	public bool Open;
    [UnityEngine.Serialization.FormerlySerializedAs("incoming")]
	public string Incoming;
	[UnityEngine.Serialization.FormerlySerializedAs("outgoing")]
	public string Outgoing;
    [UnityEngine.Serialization.FormerlySerializedAs("callCloseGate")]
	public string CallCloseGate;
	[UnityEngine.Serialization.FormerlySerializedAs("callOpenGate")]
	public string CallOpenGate;
	public string CallSetGate;

    private void Awake()
    {
        UpdateCachedFields();
        CacheMethod(Incoming, IncomingMethod);
        CacheMethod(CallCloseGate, CloseGate);
        CacheMethod(CallOpenGate, OpenGate);
        CacheMethod(CallSetGate, SetGate);
    }
    private void SetGate(object o)
    {
        bool b;
		if(o is bool) {
			Open = (bool)o;
		} else if (bool.TryParse(o.ToString(), out b))
        {
            Open = b;
        }
    }
    private void CloseGate(object o)
    {
        Open = false;
    }

    private void OpenGate(object o)
    {
        Open = true;
    }

    private void IncomingMethod(object o)
    {
        if (Open)
        {
            Call(Outgoing, cachedGameObject, o);
        }
    }
    
}
