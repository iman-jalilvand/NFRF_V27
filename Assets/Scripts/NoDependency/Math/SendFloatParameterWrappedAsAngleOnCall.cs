using UnityEngine;
using System.Collections;

public class SendFloatParameterWrappedAsAngleOnCall : Base {

    public string Incoming, Outgoing;
	void Awake () {
        CacheMethod(Incoming, Send);
	}
	void Send(object o)
    {
        float f;
        if(o is float)
        {
            f = (float)o;
            WarpFloat(f);
            Call(Outgoing, cachedGameObject, f);
        }
        else if(float.TryParse(o.ToString(), out f))
        {
            WarpFloat(f);
            Call(Outgoing, cachedGameObject, f);
        }
    }
    float WarpFloat(float f)
    {
        if (f < 0)
        {
            f = f % 360 + 360;
        }
        else
        {
            f = f % 360;
        }
        return f;
    }
}
