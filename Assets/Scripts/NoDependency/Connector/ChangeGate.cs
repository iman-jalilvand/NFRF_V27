using UnityEngine;
using System.Collections;

public class ChangeGate : Base {

	public string Incoming;
	public string Outgoing;

    public object obj;
	// Use this for initialization
	void Awake ()
    {
        CacheMethod(Incoming, Gate);
    }
	void Gate(object o)
    {
        if(o != obj)
        {
            obj = o;
            Call(Outgoing, cachedGameObject, o);
        }
    }
}
