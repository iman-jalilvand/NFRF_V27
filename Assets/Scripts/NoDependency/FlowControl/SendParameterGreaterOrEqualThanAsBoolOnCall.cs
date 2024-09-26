using UnityEngine;
using System.Collections;

public class SendParameterGreaterOrEqualThanAsBoolOnCall : Base {
    public string Incoming;
	public string Outgoing;
    public string SetValue;
    public float Value;
	// Use this for initialization
	void Awake ()
    {
        CacheMethod(Incoming, Send);
        CacheMethod(SetValue, Set);
    }
    void Send(object o)
    {
        float f;
        if(o is float)
        {
            Call(Outgoing, cachedGameObject, (float)o >= Value);
        }
        else if (o is int)
        {
            Call(Outgoing, cachedGameObject, (float)(int)o >= Value);
        }
        else if(float.TryParse(o.ToString(),out f))
        {
            Call(Outgoing, cachedGameObject, f >= Value);
        }
    }
    void Set(object o)
    {
        if(o is float)
        {
            Value = (float)o;
        }
    }
}
