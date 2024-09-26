using UnityEngine;
using System.Collections;

public class SendIntParameterGreaterThanAsBoolOnCall : Base {
    public string Incoming;
	public string Outgoing;
    public string SetValue;
    public int Value;
	// Use this for initialization
	void Awake ()
    {
        CacheMethod(Incoming, Send);
        CacheMethod(SetValue, Set);
    }
    void Send(object o)
    {
        int i;
        if(o is int)
        {
            Call(Outgoing, cachedGameObject, (int)o > Value);
        }
        else if (o is float)
        {
            Call(Outgoing, cachedGameObject, (int)(float)o > Value);
        }
        else if(int.TryParse(o.ToString(),out i))
        {
            Call(Outgoing, cachedGameObject, i > Value);
        }
    }
    void Set(object o)
    {
        if(o is int)
        {
            Value = (int)o;
        }
    }
}
