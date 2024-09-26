using UnityEngine;
using System.Collections;

public class BoolParameterGate : Base
{
    public string Incoming;
	public string Outgoing;
    public bool Invert;

    private void Awake()
    { 
        CacheMethod(Incoming, IncomingMethod);
    }

    private void IncomingMethod(object o)
    {
        bool b;
        if (bool.TryParse(o.ToString(),out b))
        {
            if(Invert)
            {
                b = !b;
            }
            if (b)
            {
                Call(Outgoing, cachedGameObject, b);
            }
        }
    }
    
}
