using UnityEngine;
using System.Collections;

public class SendParameterLessThanAsBoolOnCall : Base {
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
		if(o is float) {
			Call(Outgoing, cachedGameObject, Value > ((float) o));
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
